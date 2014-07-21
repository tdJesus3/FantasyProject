using RestSharp.Deserializers;

namespace YahooFantasy.Api.Models
{
	public class Stat
	{
		[DeserializeAs(Name = "stat")]
		public StatDetail StatDetail { get; set; }
	}
}