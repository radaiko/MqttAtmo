using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class MeasureBody
    {
        [JsonPropertyName("items")]
        public Item[] Items { get; set; }
    }
}