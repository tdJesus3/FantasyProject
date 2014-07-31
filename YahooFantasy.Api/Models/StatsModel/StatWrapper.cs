using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models.StatsModel
{
	public class StatWrapper
	{
		public string Position { get; set; }

		public string Team { get; set; }

		public string TeamAbbr { get; set; }

		public List<Stat> Stats { get; set; }
	}
}
