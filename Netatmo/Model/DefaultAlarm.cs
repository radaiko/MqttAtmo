using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class DefaultAlarm
    {
        [JsonPropertyName("db_alarm_number")]
        public int DbAlarmNumber { get; set; }
    }



}
