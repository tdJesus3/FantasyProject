using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooJsonPlayground.YahooModels.Leagues
{
	public class League
	{
		[JsonProperty(PropertyName = "league_key")]
		public string LeagueKey { get; set; }

		[JsonProperty(PropertyName = "name")]
		public string Name { get; set; }

		[JsonProperty(PropertyName = "is_pro_league")]
		public string IsProLeague { get; set; }

		[JsonProperty(PropertyName = "num_teams")]
		public string NumTeams { get; set; }
	}
}
