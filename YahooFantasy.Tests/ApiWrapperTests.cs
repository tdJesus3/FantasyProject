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

			foreach (var player in players.Take(5))
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

			var playerTypes = new List<string>();
			var playerPositions = new List<string>();

			using (var context = new FantasyContext())
			{
				foreach (var player in players)
				{
					if (!playerTypes.Any(p => p == player.PositionType))
					{
						playerTypes.Add(player.PositionType);
					}

					if (!playerPositions.Any(p => p == player.DisplayPosition))
					{
						playerPositions.Add(player.DisplayPosition);
					}

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
						case "DP":
							dbPlayer.PlayerType = SimplePlayerTypes.DefensivePlayer;
							break;
						case "DT":
							dbPlayer.PlayerType = SimplePlayerTypes.TeamDefense;
							break;
						default:
							dbPlayer.PlayerType = SimplePlayerTypes.Unknown;
							break;
					}

					var position = player.DisplayPosition;
					string primaryPosition;
					try
					{
						primaryPosition = position.Substring(0, position.IndexOf(','));
					}
					catch
					{
						primaryPosition = position;
					}

					switch (primaryPosition)
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
						case "DEF":
							dbPlayer.PrimaryPosition = SimplePositionTypes.TeamDefense;
							break;
						case "K":
							dbPlayer.PrimaryPosition = SimplePositionTypes.Kicker;
							break;
						case "CB":
							dbPlayer.PrimaryPosition = SimplePositionTypes.Cornerback;
							break;
						case "DT":
							dbPlayer.PrimaryPosition = SimplePositionTypes.DefensiveTackle;
							break;
						case "S":
							dbPlayer.PrimaryPosition = SimplePositionTypes.Safety;
							break;
						case "LB":
							dbPlayer.PrimaryPosition = SimplePositionTypes.Linebacker;
							break;
						case "DE":
							dbPlayer.PrimaryPosition = SimplePositionTypes.DefensiveEnd;
							break;
						default:
							dbPlayer.PrimaryPosition = SimplePositionTypes.Unknown;
							break;
					}

					context.Players.Add(dbPlayer);
				}

				context.SaveChanges();
			}
		}

		[TestMethod]
		public void TestFillAnnualStatsForOffensivePlayers()
		{
			var wrapper = new Api.ApiWrapper("nfl");

			using (var context = new FantasyContext())
			{
				var players = context.Players.ToList();
				var playerStats = context.Stats.ToList();

				var years = Enumerable.Range(2001, 13).OrderByDescending(i => i).ToList();
				var positions = new List<SimplePositionTypes>
				{
					SimplePositionTypes.Quarterback,
					SimplePositionTypes.Runningback,
					SimplePositionTypes.Receiver,
					SimplePositionTypes.TightEnd,
					SimplePositionTypes.Kicker
				};

				var validPlayers = from pl in players
								   join po in positions
								   on pl.PrimaryPosition equals po
								   select pl;

				foreach (var player in validPlayers)
				{
					foreach (var year in years)
					{
						var shouldPull = !playerStats.Any(ps => ps.Player.YahooPlayerId == player.YahooPlayerId &&
							ps.Year.Year == year);

						if (!shouldPull) continue;

						var stats = new StatWrapper();
						try
						{
							stats = wrapper.GetStatDataByPlayer(player.YahooPlayerId.ToString(), year.ToString());
						}
						catch
						{
							if (stats.Stats == null) continue;
						}

						if (stats != null)
						{
							var simpleStat = new SimpleStats
							{
								Player = player,
								Year = new DateTime(year, 1, 1),
								Week = null,
								TeamName = stats.Team,
								TeamAbbreviation = stats.TeamAbbr
							};

							switch (stats.Position)
							{
								case "QB":
									simpleStat.Position = SimplePositionTypes.Quarterback;
									break;
								case "RB":
									simpleStat.Position = SimplePositionTypes.Runningback;
									break;
								case "WR":
									simpleStat.Position = SimplePositionTypes.Receiver;
									break;
								case "TE":
									simpleStat.Position = SimplePositionTypes.TightEnd;
									break;
								case "DEF":
									simpleStat.Position = SimplePositionTypes.TeamDefense;
									break;
								case "K":
									simpleStat.Position = SimplePositionTypes.Kicker;
									break;
								case "CB":
									simpleStat.Position = SimplePositionTypes.Cornerback;
									break;
								case "DT":
									simpleStat.Position = SimplePositionTypes.DefensiveTackle;
									break;
								case "S":
									simpleStat.Position = SimplePositionTypes.Safety;
									break;
								case "LB":
									simpleStat.Position = SimplePositionTypes.Linebacker;
									break;
								case "DE":
									simpleStat.Position = SimplePositionTypes.DefensiveEnd;
									break;
								default:
									simpleStat.Position = SimplePositionTypes.Unknown;
									break;
							}

							foreach (var stat in stats.Stats)
							{
								var props = simpleStat.GetType().GetProperties();
								foreach (var prop in props)
								{
									if (prop.CustomAttributes.Any(p => p.AttributeType == typeof(PlayerMappingAttribute)))
									{
										var attr = prop.GetCustomAttributes(typeof(PlayerMappingAttribute), false).FirstOrDefault();
										var statId = ((PlayerMappingAttribute)attr).YahooStatId;

										if (stat.StatDetail.StatId == statId)
										{
											if (prop.PropertyType == typeof(int?))
											{
												int nullableValue = 0;
												int.TryParse(stat.StatDetail.Value, out nullableValue);
												prop.SetValue(simpleStat, nullableValue);
											}
											else
											{
												var statValue = Convert.ChangeType(stat.StatDetail.Value, prop.PropertyType);
												prop.SetValue(simpleStat, statValue);
											}
										}
									}
								}
							}

							context.Stats.Add(simpleStat);
							context.SaveChanges();
						}
					}
				}
			}
		}
	}
}