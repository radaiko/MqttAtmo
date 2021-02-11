using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class AlarmConfig
    {
        [JsonPropertyName("default_alarm")]
        public List<DefaultAlarm> DefaultAlarm { get; set; }

        [JsonPropertyName("personnalized")]
        public List<object> Personnalized { get; set; }
    }



}
