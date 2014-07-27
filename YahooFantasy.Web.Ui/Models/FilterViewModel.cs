using System;
using System.Collections.Generic;
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

		public PositionViewModel SelectedPosition { get; set; }

		public string SelectedYear { get; set; }

		public List<PositionViewModel> Positions { get; set; }

		public List<string> Years { get; set; }
	}
}