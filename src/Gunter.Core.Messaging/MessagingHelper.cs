using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Infrastructure.Log;
using Gunter.Core.Messaging.Models;
using MQTTnet;
using MQTTnet.Server;
using System.Text;

namespace Gunter.Core.Messaging
{
    public class MessagingHelper
    {
        public const string BrokerIp = "127.0.0.1";
        public const string ManagerID = "Manager";

        private static readonly Lazy<MessagingHelper> lazy = new(() => new MessagingHelper());

        public delegate void MessageReceivedEventHandler(object sender, TextMessageReceivedEventArgs e);

        private MessagingClient? messagingClient;
        private MqttServer? mqttServer;

        public static MessagingHelper Instance { get { return lazy.Value; } }

        private MessagingHelper()
        {

        }

        public async Task InitializeServer()
        {
            await CreateServer();
            messagingClient = CreateClient(ManagerID);
            messagingClient.TextMessageReceived += (sender, e) =>
            {
                var a = e.Message;
            };
        }

        public async Task CloseServer()
        {
            if (mqttServer is not null)
                await mqttServer.StopAsync();
        }

        private async Task CreateServer()
        {
            var mqttFactory = new MqttFactory();

            // The port for the default endpoint is 1883.
            // The default endpoint is NOT encrypted!
            // Use the builder classes where possible.
            var mqttServerOptions = new MqttServerOptionsBuilder()
                .WithDefaultEndpoint()
                .Build();

            // The port can be changed using the following API (not used in this example).
            // new MqttServerOptionsBuilder()
            //     .WithDefaultEndpoint()
            //     .WithDefaultEndpointPort(1234)
            //     .Build();

            mqttServer = mqttFactory.CreateMqttServer(mqttServerOptions);
            mqttServer.ClientConnectedAsync += async (ClientConnectedEventArgs e) =>
            {
                GunterLog.Instance.Log(this, $"{e.ClientId} connected");
            };

            mqttServer.ApplicationMessageNotConsumedAsync += async (ApplicationMessageNotConsumedEventArgs e) =>
            {
                var payload = e.ApplicationMessage.Payload ?? Array.Empty<byte>();
                var content = Encoding.UTF8.GetString(payload);
                GunterLog.Instance.Log(this, $"Message not consumed from {e.SenderId}: {content}");
            };

            await mqttServer.StartAsync();
        }

        public MessagingClient CreateClient(string ownerId)
            => new(ownerId);

        public async Task<List<string>> GetClientIds()
        {
            var clients = await mqttServer.GetClientsAsync();
            return clients.Select(x => x.Id).ToList();
        }
    }
}
