using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Players
{
	public class NonQuarterbackBase : OffensivePlayerBase
	{
		public int Receptions { get; set; }

		public int ReceivingYards { get; set; }

		public int ReceivingTouchdowns { get; set; }

		public int ReturnYards { get; set; }

		public int ReturnTouchdowns { get; set; }
	}
}
