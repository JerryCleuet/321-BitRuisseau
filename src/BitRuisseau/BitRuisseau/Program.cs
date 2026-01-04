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
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            List<MediaCenter> _remoteMediaCenters = new List<MediaCenter>();    // Création d'une liste factice pour juste afficher la page au début

            AppMediaCenter = new MediaCenter()
            {
                Name = "Jerry"
            };
            AppMqttService = new MqttService(AppMediaCenter);
            StartMqtt();
            Application.Run(new RemoteMediaCentersForm(AppMqttService));

        }
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
