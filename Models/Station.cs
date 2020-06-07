using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace pwiforms2.Models
{
    public class Station
    {
        [JsonProperty(PropertyName = "id")]        
        public int StationId { get; set; }

        [JsonProperty(PropertyName = "stationName")]        
        public string StationName { get; set; }
        public string Commune { get; set; }
        public string District { get; set; }
        public string Province { get; set; }
    }
}