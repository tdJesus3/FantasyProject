using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YahooFantasy.Web.Ui.Models
{
	public abstract class PlayerAnnualViewModel
	{
		public string Name { get; set; }

		public string Position { get; set; }

		public string Team { get; set; }
	}
}