using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class Item
    {
        [JsonPropertyName("beg_time")]
        public int BegTime { get; set; }

        [JsonPropertyName("step_time")]
        public int StepTime { get; set; }

        [JsonPropertyName("value")]
        public float[] Value { get; set; }
    }
}