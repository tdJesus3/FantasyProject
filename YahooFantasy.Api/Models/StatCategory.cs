using RestSharp.Deserializers;

namespace YahooFantasy.Api.Models
{
	public class StatCategory
	{
		[DeserializeAs(Name = "stat")]
		public StatCategoryDetail StatDetail { get; set; }
	}
}