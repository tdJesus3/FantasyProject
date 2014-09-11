using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YahooJsonPlayground
{
	public class JsonLeagueConverter : CustomCreationConverter<LeagueCollection>
	{
		public override LeagueCollection Create(Type objectType)
		{
			throw new NotImplementedException();
		}

		public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			var leagueList = new List<League>();
			var games = JObject.Load(reader);
			var count = (int)games["count"];

			for (int x = 0; x < count; x++)
			{
				var gameDict = games[x.ToString()];
				var game = gameDict["game"];

				if (game[0]["game_key"].ToString() == "331")
				{
					var leagues = game[1]["leagues"];
					var numLeagues = (int)leagues["count"];

					for (int y = 0; y < numLeagues; y++)
					{
						var leagueDict = leagues[y.ToString()];
						var league = leagueDict["league"][0];
						var leagueObj = JObject.Parse(league.ToString());
						var target = JsonConvert.DeserializeObject<League>(leagueObj.ToString());

						serializer.Populate(leagueObj.CreateReader(), target);
						leagueList.Add(target);
					}
				}
			}

			return new LeagueCollection { Leagues = leagueList };
		}
	}
}
