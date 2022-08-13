using MQTTnet;
using MQTTnet.Client;
using System.Text;

namespace Gunter.Core.Messaging.Models
{
    public class MessagingClient
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public event MessagingHelper.MessageReceivedEventHandler TextMessageReceived;
        private IMqttClient? mqttClient;

        public MessagingClient(string ownerId)
        {
            Id = ownerId;
        }

        public async Task ConnectAsync()
        {
            if (mqttClient is null)
                mqttClient = await CreateClient();

            if (!mqttClient.IsConnected)
                await mqttClient.ConnectAsync(new MqttClientOptionsBuilder()
                    .WithTcpServer(MessagingHelper.BrokerIp)
                    .WithClientId(Id)
                    .Build()
                , CancellationToken.None);
        }

        private async Task<IMqttClient> CreateClient()
        {
            var factory = new MqttFactory();
            var mqttClient = factory.CreateMqttClient();
            mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;
            mqttClient.ConnectedAsync += MqttClient_ConnectedAsync;
            mqttClient.ConnectingAsync += MqttClient_ConnectingAsync;
            mqttClient.DisconnectedAsync += MqttClient_DisconnectedAsync;
            mqttClient.InspectPackage += MqttClient_InspectPackage;

            return mqttClient;
        }

        public async Task DisconnectAsync()
        {
            await mqttClient.DisconnectAsync(MqttClientDisconnectReason.NormalDisconnection, "Rage Quit!");
        }

        public Task StartAsync(string brokerIp, string clientId, Action<string> callback = null)
        {
            return Task.CompletedTask;
        }

        private Task MqttClient_InspectPackage(MQTTnet.Diagnostics.InspectMqttPacketEventArgs arg)
        {
            return Task.CompletedTask;
        }

        private async Task MqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        {
            if (arg.Reason == MqttClientDisconnectReason.NormalDisconnection)
                return;

            await Task.Delay(TimeSpan.FromSeconds(5));
            await ConnectAsync();
        }

        private async Task MqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        {
            var mqttSubscribeOptions = new MqttFactory().CreateSubscribeOptionsBuilder()
                .WithTopicFilter(f => { f.WithTopic($"Components/{Id}"); })
                .Build();

            await mqttClient.SubscribeAsync(mqttSubscribeOptions, CancellationToken.None);
        }

        private Task MqttClient_ConnectingAsync(MqttClientConnectingEventArgs arg)
        {
            return Task.CompletedTask;
        }

        private Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            var sb = new StringBuilder();
            sb.AppendLine("### RECEIVED APPLICATION MESSAGE ###");
            sb.AppendLine($"+ Topic = {arg.ApplicationMessage.Topic}");
            sb.AppendLine($"+ Retain = {arg.ApplicationMessage.Retain}");
            sb.AppendLine($"+ QoS = {arg.ApplicationMessage.QualityOfServiceLevel}");
            sb.AppendLine();
            sb.AppendLine($"+ Payload = {Encoding.UTF8.GetString(arg.ApplicationMessage.Payload)}");
            sb.AppendLine();

            TextMessageReceived?.Invoke(this, new TextMessageReceivedEventArgs(sb.ToString()));

            return Task.CompletedTask;
        }

        public async Task SendToComponent(string message, string componentId)
        {
            await ConnectAsync();

            var appMessage = new MqttApplicationMessageBuilder()
                .WithTopic($"Components/{componentId}")
                .WithPayload(Encoding.UTF8.GetBytes(message))
                .Build();

            await mqttClient.PublishAsync(appMessage, CancellationToken.None);
        }
    }
}