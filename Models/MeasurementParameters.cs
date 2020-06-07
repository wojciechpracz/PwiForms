using Newtonsoft.Json;

namespace pwiforms2.Models
{
    public class MeasurementParameters
    {
        [JsonProperty(PropertyName="idParam")]
        public int ParamId { get; set; }
        [JsonProperty(PropertyName="paramName")]
        public string ParamName { get; set; }
        [JsonProperty(PropertyName="paramFormula")]
        public string ParamFormula { get; set; }
        [JsonProperty(PropertyName="paramCode")]
        public string ParamCode { get; set; }
    }
}