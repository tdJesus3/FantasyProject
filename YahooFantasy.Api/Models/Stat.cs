using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models
{
	public class Stat
	{
		[DeserializeAs(Name = "stat")]
		public StatDetail StatDetail { get; set; }
	}
}
