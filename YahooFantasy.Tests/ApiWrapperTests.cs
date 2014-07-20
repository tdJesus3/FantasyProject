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

		[TestMethod]
		public void TestInit()
		{
			var wrapper = new Api.ApiWrapper();
			wrapper.Init("nfl");
		}

		[TestMethod]
		public void TestGetPlayers()
		{
			var wrapper = new Api.ApiWrapper();
			wrapper.Init("nfl");

			wrapper.GetPlayers();
		}
	}
}
