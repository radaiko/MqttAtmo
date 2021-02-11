using System.IO;
using System.Text.Json;

namespace MqttAtmo.Config
{
    public class Configuration
    {
        public Mqtt Mqtt { get; set; }
        public Netatmo Netatmo { get; set; }

        public static Configuration Load()
        {
            var json = File.ReadAllText("config.json");
            return JsonSerializer.Deserialize<Configuration>(json);
        }
    }
}