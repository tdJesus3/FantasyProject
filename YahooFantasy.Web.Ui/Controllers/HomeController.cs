using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YahooFantasy.Api;
using YahooFantasy.Web.Ui.Models;
using YahooFantasy.Web.Ui.Models.CustomAttributes;

namespace YahooFantasy.Web.Ui.Controllers
{
	public class HomeController : Controller
	{
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

		[HttpPost]
		public ActionResult Players(FilterViewModel filter)
		{
			var api = new ApiWrapper("nfl");
			var players = api.GetPlayersByPosition(filter.SelectedPosition.Key).Take(5);
			var categories = api.GetStatCategories();

			var qbs = new List<QuarterbackAnnualViewModel>();

			foreach (var player in players)
			{
				var qb = new QuarterbackAnnualViewModel
				{
					Name = player.Name.Full,
					Position = player.EligiblePositions.FirstOrDefault().Position,
					Team = player.EditorialTeamAbbr
				};

				var stats = api.GetStatsByPlayer(player.PlayerId, filter.SelectedYear);

				foreach(var stat in stats)
				{
					var props = qb.GetType().GetProperties();
					foreach(var prop in props)
					{
						if (prop.CustomAttributes.Any(p => p.AttributeType == typeof(PlayerMappingAttribute)))
						{
							var attr = prop.GetCustomAttributes(typeof(PlayerMappingAttribute), false).FirstOrDefault();
							var statId = ((PlayerMappingAttribute)attr).YahooStatId;

							if (stat.StatDetail.StatId == statId)
							{
								var statValue = Convert.ChangeType(stat.StatDetail.Value, prop.PropertyType);
								prop.SetValue(qb, statValue);
							}
						}
					}
				}

				qbs.Add(qb);
			}

			return PartialView("_Players", qbs);
		}
	}
}