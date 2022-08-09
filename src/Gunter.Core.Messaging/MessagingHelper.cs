using Gunter.Core.Messaging.Models;
using MQTTnet.Server;
using MQTTnet;
using Gunter.Core.Infrastructure.Helpers;
using Gunter.Core.Infrastructure.Log;
using MQTTnet.Client;

namespace Gunter.Core.Messaging
{
    public class MessagingHelper
    {
        public const string BrokerIp = "127.0.0.1";


        private static readonly Lazy<MessagingHelper> lazy = new(() => new MessagingHelper());

        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);

        private MessagingClient messagingClient;
        private MqttServer mqttServer;

        public static MessagingHelper Instance { get { return lazy.Value; } }

        private MessagingHelper()
        {
            AsyncHelper.RunSync(() => CreateServer());
            messagingClient = CreateClient("Manager");
            messagingClient.MessageReceived += (sender, e) =>
            {
                var a = e.Message;
            };
        }

        ~MessagingHelper()
        {
            AsyncHelper.RunSync(() => mqttServer.StopAsync());
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
            mqttServer.ClientConnectedAsync += (ClientConnectedEventArgs e) =>
            {
                GunterLog.Instance.Log(this, $"{e.ClientId} connected");
                return Task.CompletedTask;
            };

            mqttServer.ApplicationMessageNotConsumedAsync += (ApplicationMessageNotConsumedEventArgs e) =>
            {
                return Task.CompletedTask;
            };

            await mqttServer.StartAsync();
        }

        public MessagingClient CreateClient(string ownerId)
            => new MessagingClient(ownerId);


        public List<string> GetClientIds()
        {
            var clients = AsyncHelper.RunSync(() => mqttServer.GetClientsAsync());
            return clients.Select(x => x.Id).ToList();
        }
    }
}
