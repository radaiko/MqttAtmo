using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class RoomsTemp
    {
        [JsonPropertyName("room_id")]
        public string RoomId { get; set; }

        [JsonPropertyName("temp")]
        public int Temp { get; set; }
    }



}
