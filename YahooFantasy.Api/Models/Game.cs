using Newtonsoft.Json;
using System;
using YahooFantasy.Api.Models.PlayersModel;

namespace YahooFantasy.Api.Models
{
	public class Game
	{
		[JsonProperty("game_key")]
		public string GameKey { get; set; }

		[JsonProperty("game_id")]
		public string GameId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("season")]
		public string Season { get; set; }

		[JsonProperty("stat_categories")]
		public StatCategories StatCategories { get; set; }

		[JsonProperty("players")]
		public Players Players { get; set; }
	}
}