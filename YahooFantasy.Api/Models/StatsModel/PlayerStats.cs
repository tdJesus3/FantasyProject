using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models.StatsModel
{
	public class PlayerStats
	{
		public PlayerStats()
		{
			Stats = new List<Stat>();
		}

		[JsonProperty("stats")]
		public List<Stat> Stats { get; set; }
	}
}
