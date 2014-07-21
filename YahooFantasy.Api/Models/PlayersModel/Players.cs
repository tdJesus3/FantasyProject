using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace YahooFantasy.Api.Models.PlayersModel
{
	public class Players
	{
		[DeserializeAs(Name = "0")]
		[JsonProperty("0")]
		public PlayerRoot PlayerRoot { get; set; }

		[JsonProperty("count")]
		public int Count { get; set; }
	}
}