using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace pwiforms2.Models
{
    public class ValuesFromSensor
    {                
        [JsonPropertyName("key")]        
        public string Key { get; set; }

        [JsonPropertyName("values")]
        public List<MeasuredValue> Values { get; set; }
    }
}