using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class Zone
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("rooms_temp")]
        public List<RoomsTemp> RoomsTemp { get; set; }

        [JsonPropertyName("rooms")]
        public List<Room> Rooms { get; set; }
    }



}
