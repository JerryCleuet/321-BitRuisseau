using BitRuisseau.Protocol;
using BitRuisseau.Protocol;
using BitRuisseau.Services;
using System;

namespace BitRuisseau
{
    internal static class Program
    {
        public static MediaCenter AppMediaCenter;
        public static MqttService AppMqttService;
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            List<MediaCenter> _remoteMediaCenters = new List<MediaCenter>();    // Création d'une liste factice pour juste afficher la page au début

            // Création du MediaCenter local
            AppMediaCenter = new MediaCenter()
            {
                Name = "Jerry"
            };

            AppMqttService = new MqttService(AppMediaCenter);   // Création du service MQTT avec le MediaCenter local
            StartMqtt();
            Application.Run(new RemoteMediaCentersForm(AppMqttService));    // Démarrage de l'application avec le formulaire RemoteMediaCentersForm

        }
        // Méthode pour démarrer le service MQTT de manière asynchrone
        private static async void StartMqtt()
        {
            try
            {
                await AppMqttService.StartAsync();
            }
            catch (Exception ex)
            {
                // Ne crash pas si le service MQTT ne démarre pas, renvoie une exception
                MessageBox.Show($"Impossible de d�marrer le service MQTT : {ex.Message}", "Erreur MQTT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
