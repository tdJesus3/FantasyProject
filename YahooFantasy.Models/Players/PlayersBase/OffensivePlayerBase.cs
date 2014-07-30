using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Players
{
	public abstract class OffensivePlayerBase : PlayerBase
	{
		public int FumblesLost { get; set; }

		public int RushingAttempts { get; set; }

		public int RushingYards { get; set; }

		public int RushingTouchdowns { get; set; }

		public int TwoPointConversions { get; set; }
	}
}
