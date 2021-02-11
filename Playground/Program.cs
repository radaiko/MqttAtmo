using MqttAtmo.Config;
using Netatmo;
using Netatmo.Model;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Playground
{
    class Program
    {
        static Configuration _config = Configuration.Load();
        static Api _api = new();

        static void Main(string[] args)
        {


            _api.Login(_config.Netatmo.Email, _config.Netatmo.Password, new EScope[] { EScope.read_thermostat, EScope.read_station });

            var t = Task.Run(() => GetMeasure());
            t.Wait();
            Debugger.Break();


        }

        private static async Task<LastMeasure> GetMeasure()
        {
            var homesData = await _api.GetHomesData();
            var homeId = homesData.Result.Body.Homes[0].Id;
            var roomId = homesData.Result.Body.Homes[0].Modules.Find(x => x.Type == "NATherm1").RoomId;

            var measure = await _api.GetLastRoomMeasure(homeId, roomId);

            return measure.Result;
        }
    }
}
