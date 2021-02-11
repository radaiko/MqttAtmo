using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class LastMeasure
    {
        [JsonPropertyName("body")]
        public Dictionary<string, JsonElement> Body { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("time_exec")]
        public double TimeExec { get; set; }

        [JsonPropertyName("time_server")]
        public int TimeServer { get; set; }
    }
}