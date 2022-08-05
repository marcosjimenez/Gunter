using Gunter.Core.Messaging.Models;
using MQTTnet;
using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gunter.Core.Messaging
{
    public class MessagingHelper
    {
        //private const string brokerIp = "127.0.0.1";
        //private const string clientId = "MessagingHelper";

        //private readonly MqttClientOptions options;
        //private readonly IMqttClient mqttClient;

        private static readonly Lazy<MessagingHelper> lazy = new(() => new MessagingHelper());

        public delegate void MessageReceivedEventHandler(object sender, MessageReceivedEventArgs e);
        public event MessageReceivedEventHandler MessageReceived;

        public static MessagingHelper Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public void ReceiveMessage(MessageReceivedEventArgs e)
        {

        }

        private MessagingHelper()
        {
            //var factory = new MqttFactory();
            //mqttClient = factory.CreateMqttClient();
            //options = new MqttClientOptionsBuilder()
            //    .WithTcpServer(brokerIp)
            //    .WithClientId(clientId)
            //    .Build();
        }

        //public async Task Start(string brokerIp, string clientId, Action<string> callback = null)
        //{

        //    mqttClient.ApplicationMessageReceivedAsync += MqttClient_ApplicationMessageReceivedAsync;
        //    mqttClient.ConnectedAsync += MqttClient_ConnectedAsync;
        //    mqttClient.ConnectingAsync += MqttClient_ConnectingAsync;
        //    mqttClient.DisconnectedAsync += MqttClient_DisconnectedAsync;
        //    mqttClient.InspectPackage += MqttClient_InspectPackage;

        //    await mqttClient.ConnectAsync(options, CancellationToken.None);
        //}

        //private async Task MqttClient_InspectPackage(MQTTnet.Diagnostics.InspectMqttPacketEventArgs arg)
        //{
        //    //
        //}

        //private async Task MqttClient_DisconnectedAsync(MqttClientDisconnectedEventArgs arg)
        //{

        //    Console.WriteLine("MQTT Reconnecting");
        //    await Task.Delay(TimeSpan.FromSeconds(5));
        //    await mqttClient.ConnectAsync(options, CancellationToken.None);
        //}

        //private async Task MqttClient_ConnectedAsync(MqttClientConnectedEventArgs arg)
        //{
        //    Debug.WriteLine("MQTT Connected");
        //    await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("MyTopic/test").Build());
        //}

        //private async Task MqttClient_ConnectingAsync(MqttClientConnectingEventArgs arg)
        //{
        //    //
        //}

        //private async Task MqttClient_ApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        //{
        //    var sb = new StringBuilder();
        //    sb.AppendLine("### RECEIVED APPLICATION MESSAGE ###");
        //    sb.AppendLine($"+ Topic = {arg.ApplicationMessage.Topic}");
        //    sb.AppendLine($"+ Retain = {arg.ApplicationMessage.Retain}");
        //    sb.AppendLine($"+ QoS = {arg.ApplicationMessage.QualityOfServiceLevel}");
        //    sb.AppendLine();
        //    sb.AppendLine($"+ Payload = {Encoding.UTF8.GetString(arg.ApplicationMessage.Payload)}");
        //    sb.AppendLine();

        //    MessageReceived?.Invoke(this, new MessageReceivedEventArgs(message));
        //}

        //public async Task SendCode(string message)
        //{
        //    await mqttClient.PublishAsync("MyTopic/test", message);
        //}
    }
}
