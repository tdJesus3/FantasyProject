using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YahooFantasy.Web.Ui.Models.CustomAttributes;
using GridMvc.DataAnnotations;

namespace YahooFantasy.Web.Ui.Models
{
	public class PlayerAnnualViewModel
	{
		#region Global stats
		public string Name { get; set; }

		public string Position { get; set; }

		public string Team { get; set; }

		[PlayerMappingAttribute("0")]
		[Display(Name = "Games")]
		[GridColumn(Title = "Games", SortEnabled = true, FilterEnabled = true)]
		public int GamesPlayed { get; set; }
		#endregion

		#region Passing stats
		[PlayerMappingAttribute("1")]
		[Display(Name = "Pass Att")]
		[GridColumn(Title = "Pass Att")]
		public int PassingAttempts { get; set; }

		[PlayerMappingAttribute("2")]
		[Display(Name = "Comp")]
		[GridColumn(Title = "Comp")]
		public int Completions { get; set; }

		[PlayerMappingAttribute("3")]
		[Display(Name = "Incomp")]
		[GridColumn(Title = "Incomp")]
		public int IncompletePasses { get; set; }

		[PlayerMappingAttribute("4")]
		[Display(Name = "Pass Yds")]
		[GridColumn(Title = "Pass Yds")]
		public int PassingYards { get; set; }

		[PlayerMappingAttribute("5")]
		[Display(Name = "Pass TD")]
		[GridColumn(Title = "Pass TD")]
		public int PassingTouchdowns { get; set; }

		[PlayerMappingAttribute("6")]
		[Display(Name = "Int")]
		[GridColumn(Title = "Int")]
		public int Interceptions { get; set; }

		[PlayerMappingAttribute("7")]
		[Display(Name = "Sacks")]
		[GridColumn(Title = "Sacks")]
		public int Sacks { get; set; }
		#endregion

		#region Rushing stats
		[PlayerMappingAttribute("8")]
		[Display(Name = "Rush Att")]
		[GridColumn(Title = "Rush Att")]
		public int RushingAttempts { get; set; }

		[PlayerMappingAttribute("9")]
		[Display(Name = "Rush Yds")]
		[GridColumn(Title = "Rush Yds")]
		public int RushingYards { get; set; }

		[PlayerMappingAttribute("10")]
		[Display(Name = "Rush TD")]
		[GridColumn(Title = "Rush TD")]
		public int RushingTouchdowns { get; set; }
		#endregion

		#region Receiving stats
		[PlayerMappingAttribute("11")]
		[Display(Name = "Rec")]
		[GridColumn(Title = "Rec")]
		public int Receptions { get; set; }

		[PlayerMappingAttribute("12")]
		[Display(Name = "Rec Yards")]
		[GridColumn(Title = "Rec Yards")]
		public int ReceivingYards { get; set; }

		[PlayerMappingAttribute("13")]
		[Display(Name = "Rec TDs")]
		[GridColumn(Title = "Rec TDs")]
		public int ReceivingTouchdowns { get; set; }
		#endregion

		#region Return stats
		[PlayerMappingAttribute("14")]
		[Display(Name = "Ret Yards")]
		[GridColumn(Title = "Ret Yards")]
		public int ReturnYards { get; set; }

		[PlayerMappingAttribute("15")]
		[Display(Name = "Ret TDs")]
		[GridColumn(Title = "Ret TDs")]
		public int ReturnTouchdowns { get; set; }
		#endregion

		#region Other stats
		[PlayerMappingAttribute("16")]
		[Display(Name = "2PC")]
		[GridColumn(Title = "2PC")]
		public int TwoPointConversions { get; set; }

		[PlayerMappingAttribute("18")]
		[Display(Name = "Fumbles")]
		[GridColumn(Title = "Fumbles")]
		public int FumblesLost { get; set; }
		#endregion

		#region Points
		[Display(Name = "Points")]
		[GridColumn(Title = "Points")]
		public decimal Points
		{
			get
			{
				return
					(PassingTouchdowns * 4) +
					(PassingYards * .04M) +
					(-(Interceptions * 2)) +
					(RushingYards * .10M) +
					(RushingTouchdowns * 6) +
					(ReceivingYards * .10M) +
					(ReceivingTouchdowns * 6) +
					(TwoPointConversions * 2) +
					(ReturnTouchdowns * 6) +
					(-(FumblesLost * 2));
			}
		}

		[Display(Name = "PPG")]
		[GridColumn(Title = "PPG")]
		public decimal PointsPerGame
		{
			get
			{
				return Points / GamesPlayed;
			}
		}
		#endregion
	}
}