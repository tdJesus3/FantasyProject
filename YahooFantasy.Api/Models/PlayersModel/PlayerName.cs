using Newtonsoft.Json;
namespace YahooFantasy.Api.Models.PlayersModel
{
	public class PlayerName
	{
		public string Full { get; set; }

		public string First { get; set; }

		public string Last { get; set; }

		[JsonProperty(PropertyName = "ascii_first")]
		public string AsciiFirst { get; set; }

		[JsonProperty(PropertyName = "ascii_last")]
		public string AsciiLast { get; set; }
	}
}