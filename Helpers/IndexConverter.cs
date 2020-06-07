using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pwiforms2.Models;

namespace PwiForms.Helpers
{
    public class IndexConverter: JsonConverter
    {
        
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(AirIndex));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            AirIndex index = jo.ToObject<AirIndex>();

            index.Value = jo.SelectToken("stIndexLevel.indexLevelName").ToString();

            return index;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}