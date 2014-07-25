using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models.StatsModel
{
	public class StatRoot
	{
		[JsonProperty("stats")]
		public List<Stat> Stats { get; set; }
	}
}
