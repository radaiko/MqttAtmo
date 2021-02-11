using MqttAtmo.Config;

namespace Netatmo
{
    public class EnergyApi
    {
        private readonly Configuration config = Configuration.Load();
        private readonly Api api;

        public EnergyApi(Api api)
        {
            this.api = api;
        }
        public void SetTemperature(float temp)
        {
        }

        public void GetTemperature()
        {
            //api.GetStationsData();
        }
    }
}