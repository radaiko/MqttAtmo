using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class Timetable
    {
        [JsonPropertyName("zone_id")]
        public int ZoneId { get; set; }

        [JsonPropertyName("m_offset")]
        public int MOffset { get; set; }
    }



}
