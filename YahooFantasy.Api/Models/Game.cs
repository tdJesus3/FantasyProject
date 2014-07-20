using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models
{
	public class Game
	{
		[DeserializeAs(Name = "game_key")]
		public string GameKey { get; set; }

		[DeserializeAs(Name = "game_id")]
		public string GameId { get; set; }

		public string Name { get; set; }

		public string Code { get; set; }

		public string Type { get; set; }

		public string Url { get; set; }

		public string Season { get; set; }

		[DeserializeAs(Name = "stat_categories")]
		public StatCategories StatCategories { get; set; }
	}
}
