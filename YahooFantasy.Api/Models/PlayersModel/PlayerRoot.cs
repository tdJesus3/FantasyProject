using Newtonsoft.Json;
using System.Collections.Generic;

namespace YahooFantasy.Api.Models.PlayersModel
{
	public class PlayerRoot
	{
		[JsonProperty("player")]
		public List<List<object>> Player { get; set; }
		//public object[][] Player { get; set; }
		//public List<Player> Player { get; set; }
	}
}