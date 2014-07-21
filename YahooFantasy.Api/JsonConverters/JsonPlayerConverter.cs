using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using YahooFantasy.Api.Models.PlayersModel;

namespace YahooFantasy.Api.JsonConverters
{
	public class JsonPlayerConverter : CustomCreationConverter<Player>
	{
		public override Player Create(Type objectType)
		{
			throw new NotImplementedException();
		}

		public Player Create(Type objectType, JObject obj)
		{
			var array = obj["player"][0];
			var content = array.Children<JObject>();

			var player = new Player();
			foreach (var prop in player.GetType().GetProperties().Where(pl => pl.GetType() == typeof(String)))
			{
				var attr = prop.GetCustomAttributes(typeof(JsonPropertyAttribute), false).FirstOrDefault();
				var propName = ((JsonPropertyAttribute)attr).PropertyName;

				var jsonElement = content.FirstOrDefault(c => c.Properties().Any(p => p.Name == propName));
				var value = jsonElement.GetValue(propName);

				prop.SetValue(prop, (String)value);
			}
			return player;
		}

		public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
		{
			var obj = JObject.Load(reader);
			var target = Create(objectType, obj);
			serializer.Populate(obj.CreateReader(), target);

			return target;
		}
	}
}