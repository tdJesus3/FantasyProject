using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YahooFantasy.Web.Ui.Models.CustomAttributes;

namespace YahooFantasy.Web.Ui.Models
{
	public class QuarterbackAnnualViewModel : PlayerAnnualViewModel
	{
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

		[PlayerMappingAttribute("8")]
		public int RushingAttempts { get; set; }

		[PlayerMappingAttribute("9")]
		public int RushingYards { get; set; }

		[PlayerMappingAttribute("10")]
		public int RushingTouchdowns { get; set; }
	}
}