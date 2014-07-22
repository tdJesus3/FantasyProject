﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using YahooFantasy.Api.JsonConverters;
using YahooFantasy.Api.Models;
using YahooFantasy.Api.Models.PlayersModel;

namespace YahooFantasy.Api
{
	public static class Extensions
	{
		public static void AddJsonParam(this RestRequest request)
		{
			request.AddParameter("format", "json");
		}
	}

	public class ApiWrapper
	{
		private const string ConsumerKey = "dj0yJmk9d2k1UVdlS0RlWWFGJmQ9WVdrOVRVbFlkbW8xTkc4bWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD02OA--";
		private const string Secret = "b1bf7c4b847dfcd294129b32266c65eb08360169";
		private const string BaseUrl = "http://fantasysports.yahooapis.com/fantasy/v2/";

		private readonly string _gameType;
		private readonly RestClient _client;

		private readonly Dictionary<string, string> _nflGameKeys =
			new Dictionary<string, string>
			{
				{ "2001", "57" },
				{ "2002", "49" },
				{ "2003", "79" },
				{ "2004", "101" },
				{ "2005", "124" },
				{ "2006", "153" },
				{ "2007", "175" },
				{ "2008", "199" },
				{ "2009", "222" },
				{ "2010", "242" },
				{ "2011", "257" },
				{ "2012", "273" },
				{ "2013", "300" }
			};

		public StatCategories StatCategories { get; set; }

		public ApiWrapper(string gameType)
		{
			_client = new RestClient(BaseUrl);
			_client.Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, Secret, "", "");
			_gameType = gameType;
		}

		/// <summary>
		/// Get all players. The API *appears* to limit us to 25 records per call.
		/// This method should probably be private.
		/// </summary>
		/// <returns>List of Player</returns>
		public List<Player> GetAllPlayers()
		{
			var playerList = new List<Player>();

			int start = 0;
			int count = 25;
			var proceed = true;

			while (proceed)
			{
				try
				{
					var request =
						new RestRequest("game/{gameType}/players;start={start};count={count}", Method.GET);
					request.AddUrlSegment("gameType", _gameType);
					request.AddUrlSegment("start", start.ToString());
					request.AddUrlSegment("count", count.ToString());
					request.AddJsonParam();

					var response = _client.Execute(request);
					var json = JObject.Parse(response.Content);
					var playersJson = json["fantasy_content"]["game"][1]["players"];

					// Remove the count element
					playersJson.Last.Remove();

					var players = JsonConvert.DeserializeObject<Dictionary<string, Player>>(
						playersJson.ToString(), new JsonPlayerConverter());

					playerList.AddRange(players.Values);

					start += count;
				}
				catch
				{
					proceed = false;
				}
			}

			return playerList;
		}

		public void GetStatsByPlayer(string playerId, string year)
		{
			// todo: parameter sanity checks
			string yearKey;
			if (!_nflGameKeys.TryGetValue(year, out yearKey))
				return;

			var request = new RestRequest("player/{yearKey}.p.{playerId}/stats");
			request.AddUrlSegment("yearKey", yearKey);
			request.AddUrlSegment("playerId", playerId);
			request.AddJsonParam();

			var response = _client.Execute(request);
			var data = response.Content;
		}

		public void GetWeeklyStatsByPlayer(string playerId, string year, int week)
		{
			// todo: parameter sanity checks
			string yearKey;
			if (!_nflGameKeys.TryGetValue(year, out yearKey))
				return;

			var request = new RestRequest("player/{yearKey}.p.{playerId}/stats;type=week;week={week}");
			request.AddUrlSegment("yearKey", yearKey);
			request.AddUrlSegment("playerId", playerId);
			request.AddUrlSegment("week", week.ToString());
			request.AddJsonParam();

			var response = _client.Execute(request);
			var data = response.Content;
		}

		/// <summary>
		/// Get a StatCategories object for the requested game type.
		/// The StatCategories object contains a list of Stats.
		/// </summary>
		/// <returns>StatCategories</returns>
		public StatCategories GetStatCategories()
		{
			// todo: Possibly return a List<Stat> instead of the root StatCategories object
			var request = new RestRequest("game/{gameType}/stat_categories", Method.GET);
			request.AddUrlSegment("gameType", _gameType);
			request.AddJsonParam();

			try
			{
				var response = _client.Execute<FantasyModel>(request);
				var data = (FantasyModel)response.Data;

				if (data != null && data.FantasyContent != null && data.FantasyContent.Game[1] != null)
					return data.FantasyContent.Game[1].StatCategories;
			}
			catch
			{
				throw;
			}

			return null;
		}

		private string GetYearKey(string year)
		{
			string yearKey;
			if (!_nflGameKeys.TryGetValue(year, out yearKey))
				throw new ArgumentException("Invalid year.", "year");

			return yearKey;
		}
	}
}