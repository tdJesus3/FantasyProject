using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models
{
	public class LeagueSettings
	{
		public string LeagueKey { get; set; }

		public string Name { get; set; }

		public int NumTeams { get; set; }

		public decimal PointsPerReception { get; set; }

		public decimal PointsPerPassingTd { get; set; }
	}
}
