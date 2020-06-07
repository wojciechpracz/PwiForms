using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using pwiforms2.Models;

namespace PwiForms.Helpers
{
    public class StationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Station));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            Station station = jo.ToObject<Station>();
            station.Commune = jo.SelectToken("city.commune.communeName").ToString();
            station.District =  jo.SelectToken("city.commune.districtName").ToString();
            station.Province =  jo.SelectToken("city.commune.provinceName").ToString();
            return station;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}