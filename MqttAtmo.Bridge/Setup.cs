using MqttAtmo.Config;
using Netatmo;
using Netatmo.Model;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace MqttAtmo.Bridge
{
    public class Setup
    {
        Configuration _config = Configuration.Load();
        Api _api = new();
        private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        public void Start()
        {
            _api.Login(_config.Netatmo.Email, _config.Netatmo.Password, new EScope[] { EScope.read_thermostat, EScope.read_station });
            Task.Run(() => SetupDatabaseAsync()).Wait();
        }

        public async Task SetupDatabaseAsync()
        {

            // Get HomesData
            var homesData = await _api.GetHomesData();
            File.WriteAllText(@"api\homesData.json", JsonSerializer.Serialize(homesData, serializerOptions));

            // Get HomeStatus
        }
    }
}
