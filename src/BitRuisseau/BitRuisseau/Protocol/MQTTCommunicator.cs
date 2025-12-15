using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Protocol;
using System.Buffers;

namespace BitRuisseau.Protocol
{
    public class SimpleMqttCommunicator
    {
        private readonly string _brokerHost;
        private readonly string _nodeId;
        private readonly string _topic;
        private IMqttClient _client;
        public Action<Envelope>? OnMessageReceived { private get; set; }

        public SimpleMqttCommunicator(string brokerHost, string nodeId, string topic = "users")
        {
            _brokerHost = brokerHost;
            _nodeId = nodeId;
            _topic = topic;
        }

        public async Task StartAsync()
        {
            var factory = new MqttClientFactory();
            _client = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(_brokerHost, 1883)
                .WithClientId(_nodeId)
                .WithCleanSession()
                .Build();

            _client.ApplicationMessageReceivedAsync += e =>
            {
                // Conversion ReadOnlySequence<byte> en byte[]
                var payloadBytes = ReadOnlySequenceToArray(e.ApplicationMessage.Payload);
                var payload = payloadBytes.Length == 0 ? "" : Encoding.UTF8.GetString(payloadBytes);

                if (!string.IsNullOrEmpty(payload))
                {
                    var env = JsonSerializer.Deserialize<Envelope>(payload);
                    if (env != null && OnMessageReceived != null)
                        OnMessageReceived(env);
                }
                return Task.CompletedTask;
            };

            await _client.ConnectAsync(options);
            await _client.SubscribeAsync(_topic, MqttQualityOfServiceLevel.AtLeastOnce);
        }

        public async Task SendAsync(Envelope envelope)
        {
            if (!_client.IsConnected)
                await _client.ConnectAsync(new MqttClientOptionsBuilder()
                    .WithTcpServer(_brokerHost, 1883)
                    .WithClientId(_nodeId)
                    .Build());

            var message = new MqttApplicationMessageBuilder()
                .WithTopic(_topic)
                .WithPayload(JsonSerializer.Serialize(envelope))
                .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
                .Build();

            await _client.PublishAsync(message);
        }

        public void Send(Envelope envelope) => SendAsync(envelope).Wait();

        public async Task StopAsync()
        {
            if (_client.IsConnected)
                await _client.DisconnectAsync();
        }

        public void Stop() => StopAsync().Wait();

        // Utilitaire pour convertir ReadOnlySequence<byte> en byte[]
        private static byte[] ReadOnlySequenceToArray(ReadOnlySequence<byte> sequence)
        {
            if (sequence.IsSingleSegment)
                return sequence.First.Span.ToArray();
            return sequence.ToArray();
        }
    }
}
