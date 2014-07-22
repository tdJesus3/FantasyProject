using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace YahooFantasy.Tests
{
	[TestClass]
	public class ApiWrapperTests
	{
		[TestMethod]
		public void TestGetStatCategories()
		{
			var wrapper = new Api.ApiWrapper("nfl");
			wrapper.GetStatCategories();
		}

		[TestMethod]
		public void TestInit()
		{
			var wrapper = new Api.ApiWrapper("nfl");
		}

		[TestMethod]
		public void TestGetPlayers()
		{
			var wrapper = new Api.ApiWrapper("nfl");

			wrapper.GetAllPlayers();
		}

		[TestMethod]
		public void TestGetPlayerStats()
		{
			var wrapper = new Api.ApiWrapper("nfl");

			wrapper.GetStatsByPlayer("5479", "2009");
		}
	}
}