using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class User
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("locale")]
        public string Locale { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("feel_like_algorithm")]
        public int FeelLikeAlgorithm { get; set; }

        [JsonPropertyName("unit_pressure")]
        public int UnitPressure { get; set; }

        [JsonPropertyName("unit_system")]
        public int UnitSystem { get; set; }

        [JsonPropertyName("unit_wind")]
        public int UnitWind { get; set; }

        [JsonPropertyName("all_linked")]
        public bool AllLinked { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("app_telemetry")]
        public bool AppTelemetry { get; set; }
    }



}
