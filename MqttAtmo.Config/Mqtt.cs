namespace MqttAtmo.Config
{
    public class Mqtt
    {
        public string ClientId { get; set; }
        public string TcpServer { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}