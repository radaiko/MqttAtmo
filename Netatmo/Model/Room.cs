using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Netatmo.Model
{
    public class Room
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("module_ids")]
        public List<string> ModuleIds { get; set; }

        [JsonPropertyName("modules")]
        public List<string> Modules { get; set; }

        [JsonPropertyName("therm_relay")]
        public string ThermRelay { get; set; }

        [JsonPropertyName("true_temperature_available")]
        public bool TrueTemperatureAvailable { get; set; }

        [JsonPropertyName("measure_offset_NAPlug_temperature")]
        public int MeasureOffsetNAPlugTemperature { get; set; }

        [JsonPropertyName("measure_offset_NAPlug_estimated_temperature")]
        public int MeasureOffsetNAPlugEstimatedTemperature { get; set; }

        [JsonPropertyName("therm_setpoint_temperature")]
        public int ThermSetpointTemperature { get; set; }
    }



}
