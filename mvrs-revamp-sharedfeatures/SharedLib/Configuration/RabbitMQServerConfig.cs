using System.Collections.Generic;

namespace SharedLib.Configuration
{
    public class RabbitMQServerConfig
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public int Port { get; set; }
        public string Exchange { get; set; }
        public List<RabbitMQChannel> Channels { get; set; }
        public string RoutingKey { get; set; }
    }
    
    public class RabbitMQChannel
    {
        public string Name { get; set; }
        public Dictionary<string, string> Queues { get; set; }
    }
}
