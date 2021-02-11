using MqttAtmo.Config;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using Netatmo;
using Netatmo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MqttAtmo.Bridge
{
    public class Logic
    {
        // MQTT
        private readonly MqttFactory _factory;
        private readonly MQTTnet.Client.IMqttClient _mqttClient;
        private readonly IMqttClientOptions _options;
        private static List<string> logs = new List<string>();

        // Bridge
        private readonly Configuration _config = Configuration.Load();

        // Netamo
        private readonly Api _api = new();

        public Logic()
        {
            #region MQTT
            // Create a new MQTT client.
            _factory = new MqttFactory();
            _mqttClient = _factory.CreateMqttClient();

            // Create TCP based options using the builder.
            // TODO: add support for password protected MQTT
            _options = new MqttClientOptionsBuilder()
                .WithClientId(_config.Mqtt.ClientId)
                .WithTcpServer(_config.Mqtt.TcpServer, _config.Mqtt.Port)
                .Build();

            // Setup Reconnect Handling
            _mqttClient.UseDisconnectedHandler(async e =>
            {
                Console.WriteLine("### DISCONNECTED FROM SERVER ###");
                await Task.Delay(TimeSpan.FromSeconds(5));

                try
                {
                    await _mqttClient.ConnectAsync(_options, CancellationToken.None);
                }
                catch
                {
                    Console.WriteLine("### RECONNECTING FAILED ###");
                }
            });

            // Setup Subscribe
            _mqttClient.UseConnectedHandler(async e =>
            {
                Console.WriteLine("### CONNECTED WITH SERVER ###");

                // Subscribe to a topic
                await _mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("/SmartHome/MqttAtmo/SetRoomThermpoint").Build());

                Console.WriteLine("### SUBSCRIBED ###");
            });

            // Callback
            _mqttClient.UseApplicationMessageReceivedHandler(e =>
            {
                Console.WriteLine("### RECEIVED APPLICATION MESSAGE ###");
                Console.WriteLine($"+ Topic = {e.ApplicationMessage.Topic}");
                Console.WriteLine($"+ Payload = {Encoding.UTF8.GetString(e.ApplicationMessage.Payload)}");
                Console.WriteLine($"+ QoS = {e.ApplicationMessage.QualityOfServiceLevel}");
                Console.WriteLine($"+ Retain = {e.ApplicationMessage.Retain}");
                Console.WriteLine();

                switch (e.ApplicationMessage.Topic)
                {
                    case "/SmartHome/MqttAtmo/SetRoomThermpoint":
                        SetRoomThermpointAsync(e.ApplicationMessage.Payload);
                        break;

                    default:
                        break;
                }
                //Task.Run(() => _mqttClient.PublishAsync("hello/world"));
            });

            // Connect
            Console.WriteLine("### Connect to Server ###");
            Task.Run(() => this.ConnectAsync()).Wait();
            #endregion

            #region Netatmo API
            var t = Task.Run(() => _api.Login(_config.Netatmo.Email, _config.Netatmo.Password, new EScope[] { EScope.read_thermostat }));
            t.Wait();
            if (!t.Result)
            {
                MqttLog("Failed to login");
                Environment.Exit(-1);
            } 

            #endregion

            // Run Logic
            while (_mqttClient.IsConnected)
            {
                //
                //
                // Get Data from Netatmo Energy
                try
                {
                    var getMeasureTask = Task.Run(() => GetMeasure());
                    getMeasureTask.Wait();
                    //var temperature = t.Result.Body.First().Value.ToString();
                    MqttPublish("/SmartHome/MqttAtmo/ActualTemperature", getMeasureTask.Result.Body.First().Value.ToString().Substring(1, getMeasureTask.Result.Body.First().Value.ToString().Length - 2));
                }
                catch (Exception e)
                {
                    MqttLog("Exception e: " + e);
                }
                


                MqttPublish("/SmartHome/MqttAtmo/LastMessage", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                Thread.Sleep(15000);
            }
        }

        private async Task ConnectAsync()
        {
            await _mqttClient.ConnectAsync(_options, CancellationToken.None);
        }

        private void MqttPublish(string topic, string content)
        {
            Task.Run(() => _mqttClient.PublishAsync(topic, content));
        }

        public async Task SetRoomThermpointAsync(byte[] payload)
        {
            var homesData = await _api.GetHomesData();
            if (homesData.IsSuccess == false)
            {
                MqttLog("GetHomesData: " + homesData.ErrorMsg);
                return;
            }
            var homeId = homesData.Result.Body.Homes[0].Id;
            var roomId = homesData.Result.Body.Homes[0].Modules.Find(x => x.Type == "NATherm1").RoomId;

            var measure = await _api.SetRoomThermpoint(homeId, roomId, EMode.manual, payload.ToString());
            if (measure.IsSuccess == false)
            {
                MqttLog("SetRoomThermpoint: " + measure.ErrorMsg);
                return;
            }

        }
        private async Task<LastMeasure> GetMeasure()
        {
            var homesData = await _api.GetHomesData();
            if (homesData.IsSuccess == false)
            {
                MqttLog("GetHomesData: " + homesData.ErrorMsg);
                return new LastMeasure();
            }
            var homeId = homesData.Result.Body.Homes[0].Id;
            var roomId = homesData.Result.Body.Homes[0].Modules.Find(x => x.Type == "NATherm1").RoomId;

            var measure = await _api.GetLastRoomMeasure(homeId, roomId);
            if (measure.IsSuccess == false)
            {
                MqttLog("GetLastRoomMeasure: " + measure.ErrorMsg);
                return new LastMeasure();
            }

            return measure.Result;
        }

        private void MqttLog(string msg)
        {
            logs.Add(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + ": " + msg);
            MqttPublish("/SmartHome/MqttAtmo/Error", string.Join("\n", logs.Skip(Math.Max(0, logs.Count() - 10)))) ;
        }


    }
}