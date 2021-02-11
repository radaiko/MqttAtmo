using System;

namespace MqttAtmo.Bridge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                switch (args[0])
                {
                    case "setup":
                        Setup setup = new();
                        setup.Start();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("### Start MQTT");
                Logic logic = new();
            }
            
        }
    }
}