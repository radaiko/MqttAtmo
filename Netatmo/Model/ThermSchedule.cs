using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class ThermSchedule
    {
        [JsonPropertyName("timetable")]
        public List<Timetable> Timetable { get; set; }

        [JsonPropertyName("zones")]
        public List<Zone> Zones { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("default")]
        public bool Default { get; set; }

        [JsonPropertyName("away_temp")]
        public int AwayTemp { get; set; }

        [JsonPropertyName("hg_temp")]
        public int HgTemp { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("selected")]
        public bool Selected { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }



}
