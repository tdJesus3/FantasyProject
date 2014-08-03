using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models.StatsModel
{
	public class TeamFullName
	{

	}

	public class TeamAbbreviation
	{

	}

	public class DisplayPosition
	{

	}

	public class StatPlayerData
	{
		[JsonProperty("editorial_team_full_name")]
		public string TeamFullName { get; set; }

		[JsonProperty("editorial_team_abbr")]
		public string TeamAbbreviation { get; set; }

		[JsonProperty("display_position")]
		public string DisplayPosition { get; set; }
	}
}
