using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using Owin.Security.Providers.Yahoo;
using System.Security.Claims;
using System.Threading.Tasks;
using TheFantasyProject.Web.Charts;

[assembly: OwinStartup("Startup", typeof(Startup))]

namespace TheFantasyProject.Web.Charts
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			var yahooOption = new YahooAuthenticationOptions()
			{
				ConsumerKey = "dj0yJmk9d2k1UVdlS0RlWWFGJmQ9WVdrOVRVbFlkbW8xTkc4bWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD02OA--",
				ConsumerSecret = "b1bf7c4b847dfcd294129b32266c65eb08360169",
				Provider = new YahooAuthenticationProvider()
				{
					OnAuthenticated = (context) =>
						{
							context.Identity.AddClaim(new Claim("AccessToken", context.AccessToken));
							context.Identity.AddClaim(new Claim("AccessTokenSecret", context.AccessTokenSecret));

							return Task.FromResult(0);
						}
				}
			};

			app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
			app.UseYahooAuthentication(yahooOption);

			//app.UseYahooAuthentication(
			//	consumerKey: "dj0yJmk9d2k1UVdlS0RlWWFGJmQ9WVdrOVRVbFlkbW8xTkc4bWNHbzlNQS0tJnM9Y29uc3VtZXJzZWNyZXQmeD02OA--",
			//	consumerSecret: "b1bf7c4b847dfcd294129b32266c65eb08360169");
		}
	}
}