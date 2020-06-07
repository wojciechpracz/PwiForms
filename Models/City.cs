using System.Text.Json.Serialization;

namespace pwiforms2.Models
{
    public class City
    {
        [JsonPropertyName("name")]        
        public string Name { get; set; }

        [JsonPropertyName("commune")]
        pwiforms2.Models.Commune Commune { get; set; }

    }
}