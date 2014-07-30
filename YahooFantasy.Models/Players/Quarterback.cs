using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Players
{
	public class Quarterback : OffensivePlayerBase
	{
		public int PassingAttempts { get; set; }

		public int Completions { get; set; }

		public int IncompletePasses { get; set; }

		public int PassingYards { get; set; }

		public int PassingTouchdowns { get; set; }

		public int Interceptions { get; set; }

		public int Sacks { get; set; }
	}
}
