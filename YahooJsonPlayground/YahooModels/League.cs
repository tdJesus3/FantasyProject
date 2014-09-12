using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooJsonPlayground.YahooModels
{
	public partial class FantasyContent
	{
		[JsonProperty("users")]
		public Dictionary<string, User> Users { get; set; }
	}

	public class User
	{

	}
}
