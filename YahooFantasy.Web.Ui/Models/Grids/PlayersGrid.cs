using GridMvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YahooFantasy.Web.Ui.Models.Grids
{
	public class PlayersGrid : Grid<PlayerAnnualViewModel>
	{
		public PlayersGrid(IQueryable<PlayerAnnualViewModel> items) : base(items) { }
	}
}