using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Shared
{
	public class Position
	{
		public int Id { get; set; }

		/* Begin INamedEntity implementation */
		public string Name { get; set; }

		public string ShortName { get; set; }
		/* End INamedEntity implementation */
	}
}
