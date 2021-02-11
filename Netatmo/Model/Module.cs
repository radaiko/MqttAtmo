using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class Module
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("setup_date")]
        public int SetupDate { get; set; }

        [JsonPropertyName("reachable")]
        public bool Reachable { get; set; }

        [JsonPropertyName("modules_bridged")]
        public List<string> ModulesBridged { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("hardware_version")]
        public int HardwareVersion { get; set; }

        [JsonPropertyName("public_ext_data")]
        public bool PublicExtData { get; set; }

        [JsonPropertyName("public_ext_counter")]
        public int PublicExtCounter { get; set; }

        [JsonPropertyName("alarm_config")]
        public AlarmConfig AlarmConfig { get; set; }

        [JsonPropertyName("bridge")]
        public string Bridge { get; set; }

        [JsonPropertyName("subtype")]
        public string Subtype { get; set; }

        [JsonPropertyName("outdoor_temperature")]
        public double? OutdoorTemperature { get; set; }

        [JsonPropertyName("outdoor_temperature_time")]
        public int? OutdoorTemperatureTime { get; set; }

        [JsonPropertyName("linked_station_mac")]
        public string LinkedStationMac { get; set; }

        [JsonPropertyName("linked_station_ext_module")]
        public string LinkedStationExtModule { get; set; }

        [JsonPropertyName("last_energy_bilan_month")]
        public int? LastEnergyBilanMonth { get; set; }

        [JsonPropertyName("last_energy_bilan_year")]
        public int? LastEnergyBilanYear { get; set; }

        [JsonPropertyName("homekit_compatible")]
        public bool? HomekitCompatible { get; set; }

        [JsonPropertyName("max_modules_nb")]
        public int? MaxModulesNb { get; set; }

        [JsonPropertyName("room_id")]
        public string RoomId { get; set; }
    }



}
