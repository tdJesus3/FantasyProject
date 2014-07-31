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

		[PlayerMappingAttribute("0")]
		public int? GamesPlayed { get; set; }

		public string TeamName { get; set; }

		public string TeamAbbreviation { get; set; }

		public SimplePositionTypes Position { get; set; }

		#region Offensive stats
		[PlayerMappingAttribute("18")]
		public int FumblesLost { get; set; }

		[PlayerMappingAttribute("8")]
		public int RushingAttempts { get; set; }

		[PlayerMappingAttribute("9")]
		public int RushingYards { get; set; }

		[PlayerMappingAttribute("10")]
		public int RushingTouchdowns { get; set; }

		[PlayerMappingAttribute("16")]
		public int TwoPointConversions { get; set; }
		#endregion

		#region QB stats
		[PlayerMappingAttribute("1")]
		public int PassingAttempts { get; set; }

		[PlayerMappingAttribute("2")]
		public int Completions { get; set; }

		[PlayerMappingAttribute("3")]
		public int IncompletePasses { get; set; }

		[PlayerMappingAttribute("4")]
		public int PassingYards { get; set; }

		[PlayerMappingAttribute("5")]
		public int PassingTouchdowns { get; set; }

		[PlayerMappingAttribute("6")]
		public int Interceptions { get; set; }

		[PlayerMappingAttribute("7")]
		public int Sacks { get; set; }
		#endregion

		#region Non-QB stats
		[PlayerMappingAttribute("11")]
		public int Receptions { get; set; }

		[PlayerMappingAttribute("12")]
		public int ReceivingYards { get; set; }

		[PlayerMappingAttribute("13")]
		public int ReceivingTouchdowns { get; set; }

		[PlayerMappingAttribute("14")]
		public int ReturnYards { get; set; }

		[PlayerMappingAttribute("15")]
		public int ReturnTouchdowns { get; set; }
		#endregion

		#region Kicker stats
		[PlayerMappingAttribute("20")]
		public int MadeFieldGoals_Zero { get; set; }

		[PlayerMappingAttribute("21")]
		public int MadeFieldGoals_Twenty { get; set; }

		[PlayerMappingAttribute("22")]
		public int MadeFieldGoals_Thirty { get; set; }

		[PlayerMappingAttribute("23")]
		public int MadeFieldGoals_Forty { get; set; }

		[PlayerMappingAttribute("24")]
		public int MadeFieldGoals_Fifty { get; set; }

		[PlayerMappingAttribute("25")]
		public int MissedFieldGoals_Zero { get; set; }

		[PlayerMappingAttribute("26")]
		public int MissedFieldGoals_Twenty { get; set; }

		[PlayerMappingAttribute("27")]
		public int MissedFieldGoals_Thirty { get; set; }

		[PlayerMappingAttribute("28")]
		public int MissedFieldGoals_Forty { get; set; }

		[PlayerMappingAttribute("29")]
		public int MissedFieldGoals_Fifty { get; set; }

		[PlayerMappingAttribute("30")]
		public int ExtraPointsMade { get; set; }

		[PlayerMappingAttribute("31")]
		public int ExtraPointsMissed { get; set; }
		#endregion

		public virtual SimplePlayer Player { get; set; }
	}
}
