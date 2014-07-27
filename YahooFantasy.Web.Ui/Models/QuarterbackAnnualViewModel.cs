using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YahooFantasy.Web.Ui.Models.CustomAttributes;

namespace YahooFantasy.Web.Ui.Models
{
	public class QuarterbackAnnualViewModel : PlayerAnnualViewModel
	{
		[PlayerMappingAttribute("1")]
		[Display(Name = "Pass Att")]
		public int PassingAttempts { get; set; }

		[PlayerMappingAttribute("2")]
		[Display(Name = "Comp")]
		public int Completions { get; set; }

		[PlayerMappingAttribute("3")]
		[Display(Name = "Incomp")]
		public int IncompletePasses { get; set; }

		[PlayerMappingAttribute("4")]
		[Display(Name = "Pass Yds")]
		public int PassingYards { get; set; }

		[PlayerMappingAttribute("5")]
		[Display(Name = "Pass TD")]
		public int PassingTouchdowns { get; set; }

		[PlayerMappingAttribute("6")]
		[Display(Name = "Int")]
		public int Interceptions { get; set; }

		[PlayerMappingAttribute("7")]
		[Display(Name = "Sacks")]
		public int Sacks { get; set; }

		[PlayerMappingAttribute("8")]
		[Display(Name = "Rush Att")]
		public int RushingAttempts { get; set; }

		[PlayerMappingAttribute("9")]
		[Display(Name = "Rush Yds")]
		public int RushingYards { get; set; }

		[PlayerMappingAttribute("10")]
		[Display(Name = "Rush TD")]
		public int RushingTouchdowns { get; set; }
	}
}