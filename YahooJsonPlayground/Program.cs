using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooJsonPlayground
{
	public class Program
	{
		static void Main(string[] args)
		{
			var leagues = GetLeagues();
			GetLeagueSettings(leagues.Leagues.First());
		}

		public static LeagueCollection GetLeagues()
		{
			var file = @"C:\Users\codyf_000\Desktop\Foosball\league_json.json";
			string json;

			using(var reader = new StreamReader(file))
				json = reader.ReadToEnd();

			var data = JObject.Parse(json);

			var games = data["fantasy_content"]["users"]["0"]["user"][1]["games"];

			var leagues = JsonConvert.DeserializeObject<LeagueCollection>(games.ToString(), new JsonLeagueConverter());
			return leagues;
		}

		public static void GetLeagueSettings(League league)
		{
			var file = @"C:\Users\codyf_000\Desktop\Foosball\league_settings_json.json";
			string json;

			using (var reader = new StreamReader(file))
				json = reader.ReadToEnd();

			var data = JObject.Parse(json);
			var test = JsonConvert.DeserializeObject<SettingsRoot>(json);
		}
	}
}
