using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YahooFantasy.Web.Ui.Models.CustomAttributes;
using GridMvc.DataAnnotations;

namespace YahooFantasy.Web.Ui.Models
{
	public abstract class PlayerAnnualViewModel
	{
		public string Name { get; set; }

		public string Position { get; set; }

		public string Team { get; set; }

		[PlayerMappingAttribute("0")]
		[Display(Name = "Games")]
		public int GamesPlayed { get; set; }
	}
}