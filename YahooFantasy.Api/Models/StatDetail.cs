using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooFantasy.Api.Models
{
	public class StatDetail
	{
		[DeserializeAs(Name = "stat_id")]
		public int StatId { get; set; }

		public string Name { get; set; }

		[DeserializeAs(Name = "display_name")]
		public string DisplayName { get; set; }

		[DeserializeAs(Name = "sort_order")]
		public string SortOrder { get; set; }

		[DeserializeAs(Name = "position_types")]
		public List<PositionTypes> PositionTypes { get; set; }
	}
}
