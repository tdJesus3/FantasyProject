using RestSharp.Deserializers;

namespace YahooFantasy.Api.Models
{
	public class PositionTypes
	{
		[DeserializeAs(Name = "position_type")]
		public string PositionType { get; set; }
	}
}