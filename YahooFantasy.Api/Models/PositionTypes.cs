using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models
{
	public class PositionTypes
	{
		[DeserializeAs(Name = "position_type")]
		public string PositionType { get; set; }
	}
}
