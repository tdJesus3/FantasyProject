﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using YahooFantasy.Api.JsonConverters;
using YahooFantasy.Api.Models;
using YahooFantasy.Api.Models.Leagues;
using YahooFantasy.Api.Models.Leagues.Settings;
using YahooFantasy.Api.Models.PlayersModel;
using YahooFantasy.Api.Models.StatsModel;

namespace YahooFantasy.Api
{
	public static class Retry
	{
		public static void Do(
			Action action,
			TimeSpan retryInterval,
			int retryCount = 3)
		{
			Do<object>(() =>
			{
				action();
				return null;
			}, retryInterval, retryCount);
		}

		public static T Do<T>(
			Func<T> action,
			TimeSpan retryInterval,
			int retryCount = 3)
		{
			var exceptions = new List<Exception>();

			for (int retry = 0; retry < retryCount; retry++)
			{
				try
				{
					return action();
				}
				catch (Exception ex)
				{
					exceptions.Add(ex);
					Thread.Sleep(retryInterval);
				}
			}

			throw new AggregateException(exceptions);
		}
	}

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
				{ "2013", "314" },
				{ "2014", "nfl" }
			};

		public Models.StatCategories StatCategories { get; set; }

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

		public List<Player> GetPlayersByPosition(string position)
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
						new RestRequest("game/{gameType}/players;position={position};start={start};count={count}", Method.GET);
					request.AddUrlSegment("gameType", _gameType);
					request.AddUrlSegment("start", start.ToString());
					request.AddUrlSegment("count", count.ToString());
					request.AddUrlSegment("position", position);
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

		public List<Models.StatsModel.Stat> GetStatsByPlayer(string playerId, string year)
		{
			// todo: parameter sanity checks
			string yearKey;
			if (!_nflGameKeys.TryGetValue(year, out yearKey))
				return null;

			var request = new RestRequest("player/{yearKey}.p.{playerId}/stats");
			request.AddUrlSegment("yearKey", yearKey);
			request.AddUrlSegment("playerId", playerId);
			request.AddJsonParam();

			var stats = new List<Models.StatsModel.Stat>();
			try
			{
				var response = _client.Execute(request);
				var json = JObject.Parse(response.Content);
				var playerStats = json["fantasy_content"]["player"][1]["player_stats"]["stats"];
				stats = JsonConvert.DeserializeObject<List<Models.StatsModel.Stat>>(playerStats.ToString());
			}
			catch
			{
				return stats;
			}

			return stats;
		}

		public StatWrapper GetStatDataByPlayer(string playerId, string year)
		{
			// todo: parameter sanity checks
			string yearKey;
			if (!_nflGameKeys.TryGetValue(year, out yearKey))
				return null;

			var request = new RestRequest("player/{yearKey}.p.{playerId}/stats");
			request.AddUrlSegment("yearKey", yearKey);
			request.AddUrlSegment("playerId", playerId);
			request.AddJsonParam();

			var stats = new List<Models.StatsModel.Stat>();
			var statWrapper = new StatWrapper();
			try
			{
				var response = _client.Execute(request);
				var json = JObject.Parse(response.Content);

				var statMetadataJson = json["fantasy_content"]["player"][0];
				var statMetadata = JsonConvert.DeserializeObject<List<Tuple<string, string>>>(statMetadataJson.ToString());

				var teamName = statMetadata.FirstOrDefault(tup => tup.Item1 == "editorial_team_full_name").Item2;
				var teamAbbreviation = statMetadata.FirstOrDefault(tup => tup.Item1 == "editorial_team_abbr").Item2;
				var playerPosition = statMetadata.FirstOrDefault(tup => tup.Item1 == "display_position").Item2;

				var playerStats = json["fantasy_content"]["player"][1]["player_stats"]["stats"];

				stats = JsonConvert.DeserializeObject<List<Models.StatsModel.Stat>>(playerStats.ToString());

				statWrapper.Position = playerPosition;
				statWrapper.Team = teamName;
				statWrapper.TeamAbbr = teamAbbreviation;
				statWrapper.Stats = stats;
			}
			catch
			{
				throw;
			}

			return statWrapper;
		}

		public StatWrapper GetWeeklyStatsByPlayer(string playerId, string year, int week)
		{
			// todo: parameter sanity checks
			string yearKey;
			if (!_nflGameKeys.TryGetValue(year, out yearKey))
				return null;

			var request = new RestRequest("player/{yearKey}.p.{playerId}/stats;type=week;week={week}");
			request.AddUrlSegment("yearKey", yearKey);
			request.AddUrlSegment("playerId", playerId);
			request.AddUrlSegment("week", week.ToString());
			request.AddJsonParam();

			var stats = new List<Models.StatsModel.Stat>();
			var statWrapper = new StatWrapper();

			try
			{
				var response = _client.Execute(request);
				var json = JObject.Parse(response.Content);

				//var statMetadataJson = json["fantasy_content"]["player"][0];
				//var statMetadata = JsonConvert.DeserializeObject<StatPlayerData>(statMetadataJson.ToString());

				//var teamName = statMetadata.TeamFullName;
				//var teamAbbreviation = statMetadata.TeamAbbreviation;
				//var playerPosition = statMetadata.DisplayPosition;

				try
				{
					var playerStats = json["fantasy_content"]["player"][1]["player_stats"]["stats"];
					stats = JsonConvert.DeserializeObject<List<Models.StatsModel.Stat>>(playerStats.ToString());

					statWrapper.Position = "";
					statWrapper.Team = "";
					statWrapper.TeamAbbr = "";
					statWrapper.Stats = stats;
				}
				catch
				{
					if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
					{
						var playerKey = yearKey + ".p." + playerId;
						var errorDescription = json["error"]["description"].Value<string>();
						if (errorDescription == "Player key '" + playerKey + "' does not exist.")
						{
							throw new KeyNotFoundException("Player key " + playerKey + " does not exist.");
						}
					}
					//if(response.ToString().Contains("999 Unable to process"))
					//{
					//	throw new Exception
					//}
				}
			}
			catch
			{
				throw;
			}

			return statWrapper;
		}

		/// <summary>
		/// Get a StatCategories object for the requested game type.
		/// The StatCategories object contains a list of Stats.
		/// </summary>
		/// <returns>StatCategories</returns>
		public Models.StatCategories GetStatCategories()
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

		private IRestResponse ExecuteRequest(IRestClient client, IRestRequest request)
		{
			var response = client.Execute(request);
			if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
				throw new UnauthorizedAccessException();

			return response;
		}

		public Tuple<LeagueCollection, string> GetLeagues(string accessToken, string tokenSecret)
		{
			//_client.Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, Secret, "", "");
			_client.Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, Secret, accessToken, tokenSecret);

			var request = new RestRequest("users;use_login=1/games;game_keys={gameKey}/leagues", Method.GET);
			request.AddUrlSegment("gameKey", "nfl");
			request.AddJsonParam();

			var response = Retry.Do<IRestResponse>(() => ExecuteRequest(_client, request), TimeSpan.FromSeconds(1), 10);

			var data = JObject.Parse(response.Content);
			var games = data["fantasy_content"]["users"]["0"]["user"][1]["games"];
			var leagues = JsonConvert.DeserializeObject<LeagueCollection>(games.ToString(), new JsonLeagueConverter());

			return Tuple.Create<LeagueCollection, string>(leagues, response.Content);

			//return leagues;
		}

		public Tuple<SettingsRoot, string> GetLeagueSettings(string accessToken, string tokenSecret, string leagueKey)
		{
			_client.Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, Secret, accessToken, tokenSecret);

			var request = new RestRequest("league/{leagueKey}/settings", Method.GET);
			request.AddUrlSegment("leagueKey", leagueKey);
			request.AddJsonParam();

			var response = Retry.Do<IRestResponse>(() => ExecuteRequest(_client, request), TimeSpan.FromSeconds(1), 10);
			//var data = JObject.Parse(response.Content);
			var settings = JsonConvert.DeserializeObject<SettingsRoot>(response.Content);

			return Tuple.Create<SettingsRoot, string>(settings, response.Content);

			//return settings;
		}

		public string GetTransactions(string accessToken, string tokenSecret, string leagueKey)
		{
			_client.Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, Secret, accessToken, tokenSecret);

			var request = new RestRequest("league/{leagueKey}/transactions;type=trade");
			request.AddUrlSegment("leagueKey", leagueKey);
			request.AddJsonParam();

			var response = Retry.Do<IRestResponse>(() => ExecuteRequest(_client, request), TimeSpan.FromSeconds(1), 10);
			//var data = JObject.Parse(response.Content);

			//var transactions = data["fantasy_content"]["league"][0]["transactions"];

			return response.Content;
		}

		#region Helpers
		private string GetYearKey(string year)
		{
			string yearKey;
			if (!_nflGameKeys.TryGetValue(year, out yearKey))
				throw new ArgumentException("Invalid year.", "year");

			return yearKey;
		}
		#endregion
	}
}