using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFantasy.Models.Base;

namespace YahooFantasy.Models.Teams
{
	public class Team : EntityBase, INamedEntity
	{
		/* Begin INamedEntity implementation */
		public string Name { get; set; }

		public string ShortName { get; set; }
		/* End INamedEntity implementation */
	}
}
