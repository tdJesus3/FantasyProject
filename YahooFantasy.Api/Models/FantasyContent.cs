using Newtonsoft.Json;
using RestSharp.Deserializers;
using System.Collections.Generic;

namespace YahooFantasy.Api.Models
{
	public class FantasyContent
	{
		[DeserializeAs(Name = "xml:lang")]
		[JsonProperty("xml:lang")]
		public string Language { get; set; }

		[DeserializeAs(Name = "yahoo:uri")]
		[JsonProperty("yahoo:uri")]
		public string YahooUri { get; set; }

		[JsonProperty("time")]
		public string Time { get; set; }

		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("refresh_rate")]
		public string RefreshRate { get; set; }

		[JsonProperty("game")]
		public List<Game> Game { get; set; }
	}
}