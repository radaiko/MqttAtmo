using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class HomesDataBody
    {
        [JsonPropertyName("homes")]
        public List<Home> Homes { get; set; }

        [JsonPropertyName("user")]
        public User User { get; set; }
    }



}
