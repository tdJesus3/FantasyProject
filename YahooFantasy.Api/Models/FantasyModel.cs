using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models
{
	public class FantasyModel
	{
		[DeserializeAs(Name = "fantasy_content")]
		public FantasyContent FantasyContent { get; set; }
	}
}
