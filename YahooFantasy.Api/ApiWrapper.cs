using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetOpenAuth.OAuth2;
using RestSharp.Authenticators;
using RestSharp;
using YahooFantasy.Api.Models;

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

		private readonly RestClient _client;

		public ApiWrapper()
		{
			_client = new RestClient(BaseUrl);
			_client.Authenticator = OAuth1Authenticator.ForProtectedResource(ConsumerKey, Secret, "", "");
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

			var response = _client.Execute<StatTypeModel>(request);
			var data = (StatTypeModel)response.Data;

			string b = "bbbb";
		}
    }
}
