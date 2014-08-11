using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
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

				//var years = Enumerable.Range(2001, 13).OrderByDescending(i => i).ToList();
				var years = Enumerable.Range(2013, 13).OrderByDescending(i => i).ToList();
				var positions = new List<SimplePositionTypes>
				{
					//SimplePositionTypes.Quarterback,
					SimplePositionTypes.Runningback,
					SimplePositionTypes.Receiver//,
					//SimplePositionTypes.TightEnd,
					//SimplePositionTypes.Kicker
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

		[TestMethod]
		public void TestFillWeeklyStatsForOffensivePlayers()
		{
			var wrapper = new Api.ApiWrapper("nfl");

			using (var context = new FantasyContext())
			{
				var players = context.Players.ToList();
				var playerStats = context.Stats.ToList();
				var noStats = context.NoStats.ToList();

				//var years = Enumerable.Range(2001, 13).OrderByDescending(i => i).ToList();
				var years = Enumerable.Range(2011, 1).OrderByDescending(i => i).ToList();
				var weeks = Enumerable.Range(1, 17).ToList();

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
						foreach (var week in weeks)
						{
							var shouldPull =
								!playerStats.Any(ps => ps.Player.YahooPlayerId == player.YahooPlayerId &&
									ps.Year.Year == year && ps.Week == week) &&
									!noStats.Any(ns => ns.Player == player &&
										ns.Week == week && ns.Year == year);

							if (!shouldPull) continue;

							var stats = new StatWrapper();
							try
							{
								stats = wrapper.GetWeeklyStatsByPlayer(player.YahooPlayerId.ToString(), year.ToString(), week);
							}
							catch (KeyNotFoundException ex)
							{
								var noStat = new NoStats
								{
									Player = player,
									Week = week,
									Year = year
								};
								context.NoStats.Add(noStat);
								context.SaveChanges();
								continue;
							}
							catch
							{
								continue;
							}

							if (stats.Stats == null) continue;

							if (stats != null)
							{
								var simpleStat = new SimpleStats
								{
									Player = player,
									Year = new DateTime(year, 1, 1),
									Week = week,
									TeamName = stats.Team ?? "",
									TeamAbbreviation = stats.TeamAbbr ?? "",
									Position = player.PrimaryPosition == null ? 0 : player.PrimaryPosition
								};

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

		[TestMethod]
		public void TestFillAdpData()
		{
			root data;
			using (var context = new FantasyContext())
			{
				var reader = new XmlSerializer(typeof(root));
				using (var file = new StreamReader(@"C:\Users\codyf_000\Documents\Visual Studio 2013\Projects\YahooFantasy\YahooFantasy.Tests\adp_xml_2011.xml"))
				{
					data = (root)reader.Deserialize(file);
				}

				var adpData = data.adp_data.Select(d => new Adp
				{
					PlayerName = d.name,
					TimesDrafted = d.times_drafted,
					OverallAdp = d.adp_overall,
					Position = d.pos,
					Team = d.team
				});

				var adpList = adpData.ToList();
				var year = DateTime.Parse(data.adp_info.start_date).Year;
				
				adpList.ForEach(a => a.Year = 2012);
				adpList.ForEach(a => context.Drafts.Add(a));
				context.SaveChanges();
			}
		}
	}
}