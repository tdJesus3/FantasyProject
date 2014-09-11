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
			var test = JsonConvert.DeserializeObject<Rootobject>(json);

			var settings = data["fantasy_content"]["league"][1]["settings"];

			var stats = settings[0]["stat_modifiers"]["stats"];
			int teamCount = 10;

			var statModifiers = JsonConvert.DeserializeObject<List<StatModifiers>>(stats.ToString());

			decimal pointsPerReception =
				statModifiers.Any(s => s.ModifiedStat.StatId == 11) ?
				statModifiers.First(s => s.ModifiedStat.StatId == 1).ModifiedStat.Value : 0M;

			decimal pointsPerPassingTd =
				statModifiers.Any(s => s.ModifiedStat.StatId == 5) ?
				statModifiers.First(s => s.ModifiedStat.StatId == 5).ModifiedStat.Value : 4M;
		}
	}
}
