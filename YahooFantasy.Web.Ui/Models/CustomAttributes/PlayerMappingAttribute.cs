using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YahooFantasy.Web.Ui.Models.CustomAttributes
{
	public class PlayerMappingAttribute : Attribute
	{
		public PlayerMappingAttribute(string yahooStatId)
		{
			YahooStatId = yahooStatId;
		}
		public string YahooStatId { get; set; }
	}
}