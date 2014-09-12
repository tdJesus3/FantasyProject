using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooJsonPlayground.YahooModels.Shared
{
	public class YahooRoot
	{
		[JsonProperty("fantasy_content")]
		public FantasyContent FantasyContent { get; set; }
	}
}
