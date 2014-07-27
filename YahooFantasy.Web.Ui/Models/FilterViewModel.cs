using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YahooFantasy.Web.Ui.Models
{
	public class FilterViewModel
	{
		public FilterViewModel()
		{
			SelectedPosition = new PositionViewModel();
			Positions = new List<PositionViewModel>();
			Years = new List<string>();
		}

		[Display(Name = "Position")]
		public PositionViewModel SelectedPosition { get; set; }

		[Display(Name = "Year")]
		public string SelectedYear { get; set; }

		public List<PositionViewModel> Positions { get; set; }

		public List<string> Years { get; set; }
	}
}