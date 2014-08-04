using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Simple
{
	// This entity exists to track stats that don't exist.
	// We don't want to hit the API if we know we will just
	// get an error.
	public class NoStats
	{
		public int Id { get; set; }

		public int Year { get; set; }

		public int Week { get; set; }

		public virtual SimplePlayer Player { get; set; }
	}
}
