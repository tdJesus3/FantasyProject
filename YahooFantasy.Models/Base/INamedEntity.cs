using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Models.Base
{
	public interface INamedEntity
	{
		string Name { get; set; }

		string ShortName { get; set; }
	}
}
