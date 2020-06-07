using Newtonsoft.Json;

namespace pwiforms2.Models
{
    public class MeasurementPosition
    {
        [JsonProperty(PropertyName="id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName="stationId")]
        public int StationId { get; set; }

        [JsonProperty(PropertyName="param")]
        public MeasurementParameters Parameters { get; set; }
    }
}