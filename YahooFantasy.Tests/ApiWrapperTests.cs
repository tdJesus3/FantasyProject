using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using YahooFantasy.Api.Models.StatsModel;
using YahooFantasy.Data;
using YahooFantasy.Models.Simple;

namespace YahooFantasy.Tests
{
	[TestClass]
	public class ApiWrapperTests
	{
		[TestMethod]
		public void TestGetStatCategories()
		{
			var wrapper = new Api.ApiWrapper("nfl");
			var stats = wrapper.GetStatCategories();
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
			var stats = wrapper.GetWeeklyStatsByPlayer("5479", "2013", 1);
		}

		[TestMethod]
		public void OutputCompleteStats()
		{
			var wrapper = new Api.ApiWrapper("nfl");

			var categories = wrapper.GetStatCategories().Stats;
			var players = wrapper.GetPlayersByPosition("QB");

			var stats = new List<StatRoot>();

			foreach(var player in players.Take(5))
			{
				Console.Write("Player: {0} - Position {1}", player.Name.Full, player.EligiblePositions.FirstOrDefault().Position);

				var playerStats = wrapper.GetStatsByPlayer(player.PlayerId, "2013");
				if (playerStats != null)
				{
					foreach (var playerStat in playerStats.Where(ps => ps.StatDetail.Value != "0"))
					{
						var statDetail = categories.FirstOrDefault(c => c.StatDetail.StatId.ToString() == playerStat.StatDetail.StatId);
						Console.WriteLine("{0} - {1}", statDetail.StatDetail.Name, playerStat.StatDetail.Value);
					}
				}
			}
		}

		[TestMethod]
		public void TestFillPlayersTable()
		{
			var wrapper = new Api.ApiWrapper("nfl");
			var players = wrapper.GetAllPlayers();

			using (var context = new FantasyContext())
			{
				foreach(var player in players)
				{
					var dbPlayer = new SimplePlayer
					{
						FirstName = player.Name.AsciiFirst,
						LastName = player.Name.AsciiLast,
						YahooPlayerId = Convert.ToInt32(player.PlayerId),
						FullName = player.Name.Full,
						UniformNumber = player.UniformNumber
					};

					switch (player.PositionType)
					{
						case "O":
							dbPlayer.PlayerType = SimplePlayerTypes.OffensivePlayer;
							break;
						case "K":
							dbPlayer.PlayerType = SimplePlayerTypes.Kicker;
							break;
						case "DST":
							dbPlayer.PlayerType = SimplePlayerTypes.TeamDefense;
							break;
						case "IDP":
							dbPlayer.PlayerType = SimplePlayerTypes.DefensivePlayer;
							break;
					}

					switch (player.DisplayPosition)
					{
						case "QB":
							dbPlayer.PrimaryPosition = SimplePositionTypes.Quarterback;
							break;
						case "RB":
							dbPlayer.PrimaryPosition = SimplePositionTypes.Runningback;
							break;
						case "WR":
							dbPlayer.PrimaryPosition = SimplePositionTypes.Receiver;
							break;
						case "TE":
							dbPlayer.PrimaryPosition = SimplePositionTypes.TightEnd;
							break;
						case "DST":
							dbPlayer.PrimaryPosition = SimplePositionTypes.TeamDefense;
							break;
						case "K":
							dbPlayer.PrimaryPosition = SimplePositionTypes.Kicker;
							break;
						case "DP":
							dbPlayer.PrimaryPosition = SimplePositionTypes.DefensivePlayer;
							break;
					}

					context.Players.Add(dbPlayer);
					context.SaveChanges();
				}
			}
		}
	}
}