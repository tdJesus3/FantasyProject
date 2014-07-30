using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFantasy.Models.Base;

namespace YahooFantasy.Models.Stats
{
	public partial class StatInterval : EntityBase
	{
		public IntervalTypes IntervalType { get; set; }

		public DateTime Year { get; set; }

		public int? Week { get; set; }
	}
}
