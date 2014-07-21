using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace YahooFantasy.Api.Models
{
	public class FantasyModel
	{
		[DeserializeAs(Name = "fantasy_content")]
		[JsonProperty("fantasy_content")]
		public FantasyContent FantasyContent { get; set; }
	}
}