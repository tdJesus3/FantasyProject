using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models.Leagues
{
	public class ModifiedStat
	{
		[JsonProperty("stat_id")]
		public int StatId { get; set; }

		[JsonProperty("value")]
		public decimal Value { get; set; }
	}
}
