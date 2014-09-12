using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooJsonPlayground.YahooModels.Shared
{
	public partial class FantasyContent
	{
		[JsonProperty("xml:lang")]
		public string Xmllang { get; set; }

		[JsonProperty("yahoo:uri")]
		public string Yahoouri { get; set; }

		[JsonProperty("time")]
		public string Time { get; set; }

		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("refresh_rate")]
		public string RefreshRate { get; set; }

		[JsonProperty("league")]
		public LeagueTest[] League { get; set; }

		[JsonProperty("game")]
		public List<Game> Game { get; set; }
	}
}
