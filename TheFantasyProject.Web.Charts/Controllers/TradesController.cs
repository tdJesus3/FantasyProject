using Microsoft.Owin.Security;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YahooFantasy.Api;
using YahooFantasy.Api.Models.Leagues;
using YahooFantasy.Api.Models.Leagues.Settings;
using YahooFantasy.Data;
using YahooFantasy.Models;

namespace TheFantasyProject.Web.Charts.Controllers
{
	public class TradesController : Controller
	{
		private IAuthenticationManager AuthenticationManager
		{
			get
			{
				return HttpContext.GetOwinContext().Authentication;
			}
		}

		#region Session Facade
		private string AccessToken
		{
			get { return (string)Session["AccessToken"]; }
			set { Session["AccessToken"] = value; }
		}

		private string TokenSecret
		{
			get { return (string)Session["TokenSecret"]; }
			set { Session["TokenSecret"] = value; }
		}
		#endregion

		public ActionResult Trades(bool? isAuthed)
		{
			ViewBag.Success = false;

			if (isAuthed.HasValue && isAuthed.Value && !String.IsNullOrEmpty(AccessToken))
			{
				try
				{
					var wrapper = new ApiWrapper("nfl");
					var leagues = wrapper.GetLeagues(AccessToken, TokenSecret);

					foreach (var league in leagues.Item1.Leagues)
					{
						var key = league.LeagueKey;
						var settings = wrapper.GetLeagueSettings(AccessToken, TokenSecret, key);
						var trans = wrapper.GetTransactions(AccessToken, TokenSecret, key);

						SaveSettings(settings.Item1, leagues.Item2, settings.Item2, trans);

						ViewBag.Success = true;
					}
				}
				catch
				{
					ViewBag.ErrorMessage = "Something went awry :( ... try again?";
				}

			}

			return View();
		}

		public ActionResult GetTrades()
		{
			return View();
		}

		public JsonResult GetTradedPlayers()
		{
			return new JsonResult();
		}

		[AllowAnonymous]
		[HttpPost]
		public ActionResult ExternalLogin(string provider, string returnUrl)
		{
			var ctx = HttpContext.GetOwinContext();
			ctx.Authentication.Challenge(
				new AuthenticationProperties
				{
					RedirectUri = Url.Action("Callback", "Trades")
				},
				provider);
			return new HttpUnauthorizedResult();
		}

		[HttpPost]
		public ActionResult LogOut()
		{
			var ctx = Request.GetOwinContext();
			ctx.Authentication.SignOut();

			return RedirectToAction("Trades");
		}

		public async Task<ActionResult> Callback()
		{
			var ctx = Request.GetOwinContext();
			var result = ctx.Authentication.AuthenticateAsync("ExternalCookie").Result;
			ctx.Authentication.SignOut("ExternalCookie");

			var claims = result.Identity.Claims.ToList();
			claims.Add(new Claim(ClaimTypes.AuthenticationMethod, "Yahoo"));

			var ci = new ClaimsIdentity(claims, "Cookie");
			ctx.Authentication.SignIn(ci);

			AccessToken = claims.First(c => c.Type == "AccessToken").Value;
			TokenSecret = claims.First(c => c.Type == "AccessTokenSecret").Value;

			return RedirectToAction("Trades", new { isAuthed = true });
		}

		public void SaveSettings(SettingsRoot settings, string leagueJson, string settingsJson, string transactionsJson)
		{
			var context = new FantasyContext();

			foreach(var league in settings.FantasyContent.Leagues)
			{
				decimal pointsPerReception = 0.0M;
				decimal pointsPerPassingTd = 4.0M;

				string ppr, ppptd;

				try
				{
					ppr = league.Settings.First()
						.StatModifiers.ModifiedStats
						.FirstOrDefault(s => s.ModifiedStat.StatId == 11)
						.ModifiedStat.Value;
				}
				catch
				{
					ppr = null;
				}

				try
				{
					ppptd = league.Settings.First()
						.StatModifiers.ModifiedStats
						.FirstOrDefault(s => s.ModifiedStat.StatId == 5)
						.ModifiedStat.Value;
				}
				catch
				{
					ppptd = null;
				}

				Decimal.TryParse(ppr, out pointsPerReception);
				Decimal.TryParse(ppptd, out pointsPerPassingTd);

				var dbLeague = new YahooFantasy.Models.Simple.Trades.League
				{
					LeagueKey = league.LeagueKey,
					NumberOfOwners = league.NumTeams,
					LeagueJson = leagueJson,
					SettingsJson = settingsJson,
					TransactionsJson = transactionsJson,
					PointsPerPassingTouchdown = pointsPerPassingTd,
					PointsPerReception = pointsPerReception
				};

				context.Leagues.Add(dbLeague);
				context.SaveChanges();
			}

		}
	}
}