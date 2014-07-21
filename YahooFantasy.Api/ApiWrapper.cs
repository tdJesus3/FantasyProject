using RestSharp;
using RestSharp.Authenticators;
using YahooFantasy.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using YahooFantasy.Api.Models.PlayersModel;
using System.Collections.Generic;
using YahooFantasy.Api.JsonConverters;

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

		private string _gameType;

		private readonly RestClient _client;

		public StatCategories StatCategories { get; set; }

		public ApiWrapper()
		{
			_client = new RestClient(BaseUrl);
			_client.Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, Secret, "", "");
		}

		public void GetPlayers()
		{
			int start = 0;
			int count = 25;
			var proceed = true;
			while (proceed)
			{
				var request =
					new RestRequest("game/{gameType}/players;start={start};count={count}", Method.GET);
				request.AddUrlSegment("gameType", _gameType);
				request.AddUrlSegment("start", start.ToString());
				request.AddUrlSegment("count", count.ToString());
				request.AddJsonParam();

				var response = _client.Execute(request);
				var json = JObject.Parse(response.Content);
				var players = json["fantasy_content"]["game"][1]["players"];
				players.Last.Remove();

				// players is now just the player elements; the count has been removed

				var playerElement = players["0"]["player"][0];
				playerElement.Last.Remove();
				playerElement.Last.Remove();

				var hateYahoo = JsonConvert.DeserializeObject<Dictionary<string, Player>>(players.ToString(), new JsonPlayerConverter());

				var playerDes = JsonConvert.DeserializeObject<Player>(playerElement.ToString(), new JsonPlayerConverter());

				// This is going to throw an error.
				// We probably need to implement a custom JsonConverter
				// See: http://stackoverflow.com/questions/13067842/json-net-deserialize-nested-arrays-into-strongly-typed-object
				//		http://stackoverflow.com/questions/8241392/deserializing-heterogenous-json-array-into-covariant-list-using-json-net

				var playerObj = JsonConvert.DeserializeObject<Player>(playerElement.ToString());

				var playersObj = JsonConvert.DeserializeObject<Dictionary<string, PlayerRoot>>(players.ToString());


				start += count;
			}
		}

		public void GetPlayerStats(string playerKey)
		{
			var request = new RestRequest("player/{playerKey}/stats_categories", Method.GET);
			request.AddUrlSegment("playerKey", playerKey);
			request.AddJsonParam();

			var response = _client.Execute(request);
			var data = response.Content;
		}

		public void GetStatCategories(string gameType)
		{
			var request = new RestRequest("game/{gameType}/stat_categories", Method.GET);
			request.AddUrlSegment("gameType", gameType);
			request.AddJsonParam();

			var response = _client.Execute<FantasyModel>(request);
			var data = (FantasyModel)response.Data;

			string b = "bbbb";
		}

		private StatCategories FillStatCategories(string gameType)
		{
			var request = new RestRequest("game/{gameType}/stat_categories", Method.GET);
			request.AddUrlSegment("gameType", gameType);
			request.AddJsonParam();

			var response = _client.Execute<FantasyModel>(request);
			var data = (FantasyModel)response.Data;

			if (data != null && data.FantasyContent != null && data.FantasyContent.Game[1] != null)
				return data.FantasyContent.Game[1].StatCategories;

			return null;
		}

		public void Init(string gameType)
		{
			_gameType = gameType;
			StatCategories = FillStatCategories(_gameType);
		}
	}
}