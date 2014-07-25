using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YahooFantasy.Api.Models.StatsModel
{
	public class StatDetail
	{
		[JsonProperty("stat_id")]
		public string StatId { get; set; }

		[JsonProperty("value")]
		public string Value { get; set; }
	}
}
