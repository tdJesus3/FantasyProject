using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models
{
	public class FantasyContent
	{
		[DeserializeAs(Name = "xml:lang")]
		public string Language { get; set; }

		[DeserializeAs(Name = "yahoo:uri")]
		public string YahooUri { get; set; }

		public string Time { get; set; }

		public string Copyright { get; set; }

		public string RefreshRate { get; set; }

		public List<Game> Game { get; set; }
	}
}
