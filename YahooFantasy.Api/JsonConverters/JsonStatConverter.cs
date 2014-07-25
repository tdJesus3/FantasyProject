using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFantasy.Api.Models.StatsModel;

namespace YahooFantasy.Api.JsonConverters
{
	public class JsonStatConverter : CustomCreationConverter<Stat>
	{
		public override Stat Create(Type objectType)
		{
			throw new NotImplementedException();
		}

		public Stat Create(Type objectType, JObject obj)
		{
			throw new NotImplementedException();
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
