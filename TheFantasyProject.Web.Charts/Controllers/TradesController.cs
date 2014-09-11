using Microsoft.Owin.Security;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using YahooFantasy.Api;

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

		public ActionResult Trades(bool? isAuthed)
		{
			if (isAuthed.HasValue && isAuthed.Value)
			{
				ViewBag.IsAuthed = true;
				var wrapper = new ApiWrapper("nfl");
				//wrapper.GetLeagues(AccessToken, TokenSecret);
				wrapper.GetLeagueSettings(AccessToken, TokenSecret, "331.l.43546");
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
	}
}