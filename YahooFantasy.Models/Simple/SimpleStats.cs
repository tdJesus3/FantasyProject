using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Simple
{
	public class SimpleStats
	{
		public int Id { get; set; }

		public DateTime Year { get; set; }

		public int? Week { get; set; }

		public int? GamesPlayed { get; set; }

		public string TeamName { get; set; }

		public string TeamAbbreviation { get; set; }

		public SimplePositionTypes Position { get; set; }

		#region Offensive stats
		public int FumblesLost { get; set; }

		public int RushingAttempts { get; set; }

		public int RushingYards { get; set; }

		public int RushingTouchdowns { get; set; }

		public int TwoPointConversions { get; set; }
		#endregion

		#region QB stats
		public int PassingAttempts { get; set; }

		public int Completions { get; set; }

		public int IncompletePasses { get; set; }

		public int PassingYards { get; set; }

		public int PassingTouchdowns { get; set; }

		public int Interceptions { get; set; }

		public int Sacks { get; set; }
		#endregion

		#region Non-QB stats
		public int Receptions { get; set; }

		public int ReceivingYards { get; set; }

		public int ReceivingTouchdowns { get; set; }

		public int ReturnYards { get; set; }

		public int ReturnTouchdowns { get; set; }
		#endregion

		public virtual SimplePlayer Player { get; set; }
	}
}
