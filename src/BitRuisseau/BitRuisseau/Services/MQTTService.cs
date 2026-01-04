using BitRuisseau.Protocol;
using BitRuisseau.Models;
using MQTTnet;
using System.Buffers;
using System.Text;
using System.Text.Json;
using Backend.Protocol;

namespace BitRuisseau.Services
{
    public class MqttService
    {
        private IMqttClient _client;
        private MediaCenter _mediaCenterInstance;
        private const string Topic = "test";   // Topic MQTT utilisé pour communiquer avec les autres
        private Dictionary<string, MediaCenter> _remoteMediaCenters = new Dictionary<string, MediaCenter>();    // Dictionnaire pour stocker les MediaCenters
        public IReadOnlyCollection<MediaCenter> RemoteMediaCenters => _remoteMediaCenters.Values;   // Collection publiques pour l'affichage des mediacenters dans l'UI
        public MqttService(MediaCenter mediaCenter)
        {
            _mediaCenterInstance = mediaCenter;
        }

        private const string BrokerHost = "mqtt.blue.section-inf.ch";
        private const int BrokerPort = 1883;
        private const string BrokerUsername = "ict";
        private const string BrokerPassword = "321";
        public async Task StartAsync()
        {
            var factory = new MqttClientFactory();
            _client = factory.CreateMqttClient();



        var options = new MqttClientOptionsBuilder()
            .WithTcpServer(BrokerHost, BrokerPort)
            .WithCredentials(BrokerUsername, BrokerPassword)
            .WithWillPayload(JsonSerializer.Serialize(new Envelope(_mediaCenterInstance.Id, null, MessageType.I_AM_OUT, "")))
            .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)
            .WithTimeout(TimeSpan.FromSeconds(10))
            .WithKeepAlivePeriod(TimeSpan.FromSeconds(60))
            .WithCleanStart(true)
            .Build();

        // event handler
        _client.ConnectedAsync += e =>
            {
                // ask all users and announce his own presence to the network
                Send(new Envelope(_mediaCenterInstance.Id, null, MessageType.WHO_IS_THERE, ""));
                return Task.CompletedTask;
            };

            _client.ApplicationMessageReceivedAsync += e =>
            {
                var topic = e.ApplicationMessage.Topic;
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload.ToArray<byte>() ?? Array.Empty<byte>());

                // deserialize content to Envelope
                // Protection contre les messages mal formés pour éviter les crashs
                Envelope? env;
                try
                {
                    env = JsonSerializer.Deserialize<Envelope>(payload);
                }
                catch
                {
                    return Task.CompletedTask;
                }

                if (env == null)
                {
                    return Task.CompletedTask;
                }

                // not processing one's own messages
                if (env.Id != _mediaCenterInstance.Id)
                {
                    OnMessageReceived(env);
                }

                return Task.CompletedTask;
            };

            // connect
            await _client.ConnectAsync(options);

            // subscribe
            await _client.SubscribeAsync(Topic);
        }

        public async Task Send(Envelope envelope)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(Topic)
                .WithPayload(JsonSerializer.Serialize(envelope))
                .Build();

            await _client.PublishAsync(message);
        }

        private async Task OnMessageReceived(Envelope envelope)
        {
            switch (envelope.Type)
            {
                case MessageType.WHO_IS_THERE:
                    await Send(new Envelope(_mediaCenterInstance.Id, null, MessageType.I_AM_HERE, JsonSerializer.Serialize(_mediaCenterInstance)));
                    break;
                case MessageType.I_AM_HERE:
                    MediaCenter? remoteMediaCenter;

                    try
                    {
                        remoteMediaCenter =
                            JsonSerializer.Deserialize<MediaCenter>(envelope.Message);
                    }
                    catch
                    {
                        break;
                    }

                    if (remoteMediaCenter == null)  // Si le message est mal formé, break
                    {
                        break;
                    }

                    if (_remoteMediaCenters.ContainsKey(remoteMediaCenter.Id))  // Si on a déjà ce MediaCenter dans la liste, break
                    {
                        break;
                    }

                    _remoteMediaCenters.Add(remoteMediaCenter.Id, remoteMediaCenter);   // Ajout du MediaCenter à la liste
                    break;

                case MessageType.I_AM_OUT:
                    _remoteMediaCenters.Remove(envelope.Id);
                    break;
            }
        }
    }
}
