using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using YahooFantasy.Api;
using YahooFantasy.Web.Ui.Models;
using YahooFantasy.Web.Ui.Models.CustomAttributes;
using Mvc.JQuery.Datatables;

namespace YahooFantasy.Web.Ui.Controllers
{
	public class HomeController : Controller
	{
		#region Session facade
		public FilterViewModel PlayerFilter
		{
			get
			{
				return (FilterViewModel)HttpContext.Session["Filter"];
			}
			set
			{
				HttpContext.Session["Filter"] = (FilterViewModel)value;
			}
		}

		public IQueryable<PlayerAnnualViewModel> PlayerData
		{
			get
			{
				return (IQueryable<PlayerAnnualViewModel>)HttpContext.Session["PlayerData"];
			}
			set
			{
				HttpContext.Session["PlayerData"] = (IQueryable<PlayerAnnualViewModel>)value;
			}
		}
		#endregion

		public ActionResult Index()
		{
			var filter = new FilterViewModel
			{
				Positions = new List<PositionViewModel>
				{
					new PositionViewModel
					{
						Name = "Quarterback",
						Key = "QB"
					},
					new PositionViewModel
					{
						Name = "Running back",
						Key = "RB"
					},
					new PositionViewModel
					{
						Name = "Wide receiver",
						Key = "WR"
					},
					new PositionViewModel
					{
						Name = "Tight end",
						Key = "TE"
					},
					new PositionViewModel
					{
						Name = "Kicker",
						Key = "K"
					},
					new PositionViewModel
					{
						Name = "Defense",
						Key = "DST"
					}
				},
				Years = new List<string>
				{
					"2001", "2002",	"2003",	"2004",	"2005", "2006", "2007", "2008", "2009", "2010", "2011", "2012", "2013"
				}
			};

			return View(filter);
		}

		//public ActionResult Players(FilterViewModel filter = null)
		//{
		//	var playersData = new PlayersGrid(GetPlayerData(filter));

		//	return PartialView("_Players", playersData);
		//}

		public DataTablesResult<PlayerAnnualViewModel> GetPlayers(DataTablesParam param, FilterViewModel filter)
		{
			if(filter != null && filter.SelectedYear != null)
			{
				PlayerFilter = filter;
			}

			var players = GetPlayerData(filter ?? PlayerFilter);
			return DataTablesResult.Create(players, param);
		}

		private IQueryable<PlayerAnnualViewModel> GetPlayerData(FilterViewModel filter)
		{
			if (PlayerFilter != null && (filter == null || filter.SelectedYear == null))
			{
				filter = PlayerFilter;
			}
			else
			{
				PlayerFilter = filter;
			}

			if(filter == null || filter.SelectedYear == null)
			{
				return new List<PlayerAnnualViewModel>().AsQueryable();
			}

			var api = new ApiWrapper("nfl");
			var players = api.GetPlayersByPosition(filter.SelectedPosition.Key).Take(25);
			var categories = api.GetStatCategories();
			var playersModel = new List<PlayerAnnualViewModel>();

			foreach (var player in players)
			{
				var playerModel = new PlayerAnnualViewModel
				{
					Name = player.Name.Full,
					Position = player.EligiblePositions.FirstOrDefault().Position,
					Team = player.EditorialTeamAbbr
				};

				var stats = api.GetStatsByPlayer(player.PlayerId, filter.SelectedYear);

				foreach (var stat in stats)
				{
					var props = playerModel.GetType().GetProperties();
					foreach (var prop in props)
					{
						if (prop.CustomAttributes.Any(p => p.AttributeType == typeof(PlayerMappingAttribute)))
						{
							var attr = prop.GetCustomAttributes(typeof(PlayerMappingAttribute), false).FirstOrDefault();
							var statId = ((PlayerMappingAttribute)attr).YahooStatId;

							if (stat.StatDetail.StatId == statId)
							{
								var statValue = Convert.ChangeType(stat.StatDetail.Value, prop.PropertyType);
								prop.SetValue(playerModel, statValue);
							}
						}
					}
				}

				if (playerModel.GamesPlayed > 0)
				{
					playersModel.Add(playerModel);
				}
			}

			return playersModel.AsQueryable();
		}

		#region File methods
		private static IEnumerable<string> ToCsv<T>(string separator, IEnumerable<T> objectlist)
		{
			var fields = typeof(T).GetFields();
			var properties = typeof(T).GetProperties();
			yield return String.Join(separator, fields.Select(f => f.Name).Union(properties.Select(p => p.Name)).ToArray());
			foreach (var o in objectlist)
			{
				yield return string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
					.Union(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray());
			}
		}
		#endregion
	}
}