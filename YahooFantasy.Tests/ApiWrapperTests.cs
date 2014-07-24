using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

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

			wrapper.GetStatsByPlayer("5479", "2013");
		}

		[TestMethod]
		public void TestGetWeeklyPlayerStats()
		{
			var wrapper = new Api.ApiWrapper("nfl");
			wrapper.GetWeeklyStatsByPlayer("5479", "2013", 1);
		}

		//[TestMethod]
		//public void OutputCompleteStats()
		//{
		//	var wrapper = new Api.ApiWrapper("nfl");

		//	var categories = wrapper.GetStatCategories();
		//	var players = wrapper.GetPlayersByPosition("QB");

		//	var stats = new List<
		//	foreach(var player in players)
		//	{
		//		wrapper.GetStatsByPlayer(player.PlayerId, "2013");
		//	}
		//}
	}
}