using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class Home
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("altitude")]
        public int Altitude { get; set; }

        [JsonPropertyName("coordinates")]
        public List<double> Coordinates { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("invitation_code")]
        public List<string> InvitationCode { get; set; }

        [JsonPropertyName("nb_users")]
        public int NbUsers { get; set; }

        [JsonPropertyName("place_improved")]
        public bool PlaceImproved { get; set; }

        [JsonPropertyName("trust_location")]
        public bool TrustLocation { get; set; }

        [JsonPropertyName("therm_absence_notification")]
        public bool ThermAbsenceNotification { get; set; }

        [JsonPropertyName("therm_absence_autoaway")]
        public bool ThermAbsenceAutoaway { get; set; }

        [JsonPropertyName("rooms")]
        public List<Room> Rooms { get; set; }

        [JsonPropertyName("modules")]
        public List<Module> Modules { get; set; }

        [JsonPropertyName("temperature_control_mode")]
        public string TemperatureControlMode { get; set; }

        [JsonPropertyName("therm_schedules")]
        public List<ThermSchedule> ThermSchedules { get; set; }

        [JsonPropertyName("therm_mode")]
        public string ThermMode { get; set; }

        [JsonPropertyName("therm_setpoint_default_duration")]
        public int ThermSetpointDefaultDuration { get; set; }

        [JsonPropertyName("anticipation")]
        public bool Anticipation { get; set; }

        [JsonPropertyName("outdoor_temperature_source")]
        public string OutdoorTemperatureSource { get; set; }

        [JsonPropertyName("therm_heating_priority")]
        public string ThermHeatingPriority { get; set; }

        [JsonPropertyName("cooling_mode")]
        public string CoolingMode { get; set; }

        [JsonPropertyName("therm_boost_default_duration")]
        public int ThermBoostDefaultDuration { get; set; }

        [JsonPropertyName("gone_after")]
        public int GoneAfter { get; set; }

        [JsonPropertyName("share_info")]
        public bool ShareInfo { get; set; }

        [JsonPropertyName("smart_notifs")]
        public bool SmartNotifs { get; set; }

        [JsonPropertyName("events_ttl")]
        public string EventsTtl { get; set; }

        [JsonPropertyName("schedules")]
        public List<Schedule> Schedules { get; set; }
    }



}
