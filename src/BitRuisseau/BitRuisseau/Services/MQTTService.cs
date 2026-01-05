using Backend.Protocol;
using BitRuisseau.Models;
using BitRuisseau.Protocol;
using MQTTnet;
using System.Buffers;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace BitRuisseau.Services
{
    public class MqttService
    {
        private IMqttClient _client;    // Client MQTT
        private MediaCenter _mediaCenterInstance;   // Instance locale du MediaCenter
        private const string Topic = "powercher/bitruisseau";   // Topic MQTT utilisé pour communiquer avec les autres
        private Dictionary<string, MediaCenter> _remoteMediaCenters = new Dictionary<string, MediaCenter>();    // Dictionnaire pour stocker les MediaCenters
        public IReadOnlyCollection<MediaCenter> RemoteMediaCenters => _remoteMediaCenters.Values;   // Collection publiques pour l'affichage des mediacenters dans l'UI
        public event Action? RemoteMediaCentersChanged; // Action pour envoyer à l'UI quand on a un changement dans la liste des mediacenters
        public MqttService(MediaCenter mediaCenter)
        {
            _mediaCenterInstance = mediaCenter;
        }

        private const string BrokerHost = "mqtt.blue.section-inf.ch";
        private const int BrokerPort = 1883;
        private const string BrokerUsername = "ict";
        private const string BrokerPassword = "321";

        // Méthode pour démarrer le service MQTT
        public async Task StartAsync()
        {
            var factory = new MqttClientFactory();
            _client = factory.CreateMqttClient();



            var options = new MqttClientOptionsBuilder()
                .WithTcpServer(BrokerHost, BrokerPort)  // Adresse du broker MQTT
                .WithCredentials(BrokerUsername, BrokerPassword)    // Authentification auprès du broker MQTT
                .WithWillPayload(JsonSerializer.Serialize(new Envelope(_mediaCenterInstance.Id, null, MessageType.I_AM_OUT, "Jerry is out")))   // Payload du message de "will"
                .WithWillQualityOfServiceLevel(MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce)  // Qualité de service pour le message de "will"
                .WithTimeout(TimeSpan.FromSeconds(10))  // Timeout de connexion
                .WithKeepAlivePeriod(TimeSpan.FromSeconds(20))  // Période de keep-alive pour maintenir la connexion
                .WithCleanStart(true)   // Fais en sorte de ne pas recevoir les messages anciens
                .Build();   // Construction des options de connexion

            // Gestion des événements MQTT
            _client.ConnectedAsync += e =>
            {
                // Après connexion, envoyer un message WHO_IS_THERE pour découvrir les autres MediaCenters
                Send(new Envelope(_mediaCenterInstance.Id, JsonSerializer.Serialize(_mediaCenterInstance), MessageType.WHO_IS_THERE, "who is there ?"));
                return Task.CompletedTask;
            };

            _client.ApplicationMessageReceivedAsync += e =>
            {
                var topic = e.ApplicationMessage.Topic;
                var payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload.ToArray<byte>() ?? Array.Empty<byte>());

                // Deserialization du message reçu
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

                // Ignorer les messages provenant de soi-même
                if (env.Id != _mediaCenterInstance.Id)
                {
                    OnMessageReceived(env);
                }

                return Task.CompletedTask;
            };

            // Se connecter
            await _client.ConnectAsync(options);

            // S'abonner au topic
            await _client.SubscribeAsync(Topic);
        }

        // Méthode pour envoyer un message MQTT
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
                case MessageType.WHO_IS_THERE:  // Quand on reçoit un WHO_IS_THERE, on répond avec I_AM_HERE
                    await Send(new Envelope(_mediaCenterInstance.Id, null, MessageType.I_AM_HERE, JsonSerializer.Serialize(_mediaCenterInstance)));
                    break;
                case MessageType.I_AM_HERE: // Quand on reçoit un I_AM_HERE, on ajoute le MediaCenter à la liste s'il n'existe pas 
                    if (envelope.Id == _mediaCenterInstance.Id)
                        break;

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
                    // Ajout du MediaCenter à la liste s'il n'existe pas déjà
                    if (!_remoteMediaCenters.ContainsKey(remoteMediaCenter.Id))
                    {
                        _remoteMediaCenters.Add(remoteMediaCenter.Id, remoteMediaCenter);   // Ajout du MediaCenter à la liste
                        RemoteMediaCentersChanged?.Invoke(); // Notifie l'UI qu'il y a un changement
                    }
                    break;

                case MessageType.I_AM_OUT:  // Quand on reçoit un I_AM_OUT, on retire le MediaCenter de la liste
                    _remoteMediaCenters.Remove(envelope.SenderId);
                    RemoteMediaCentersChanged?.Invoke(); // Notifie l'UI qu'il y a un changement
                    break;
            }
        }
    }
}
