using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFantasy.Models.Base;
using YahooFantasy.Models.Shared;
using YahooFantasy.Models.Teams;

namespace YahooFantasy.Models.Players
{
	public abstract class PlayerBase : EntityBase
	{
		public string Name { get; set; }

		public virtual Team Team { get; set; }

		public virtual Position Position { get; set; }
	}
}
