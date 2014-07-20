using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YahooFantasy.Tests
{
	[TestClass]
	public class ApiWrapperTests
	{
		[TestMethod]
		public void TestGetStatCategories()
		{
			var wrapper = new Api.ApiWrapper();
			wrapper.GetStatCategories("nfl");
		}
	}
}
