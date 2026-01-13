using Backend.Protocol;
using BitRuisseau.Protocol;
using BitRuisseau.Services;
using Microsoft.VisualBasic.Devices;
using System.Drawing.Text;
using System.Text.Json;

namespace BitRuisseau
{
    public partial class RemoteMediaCentersForm : Form
    {
        MqttService _mqttService;   // Référence au service MQTT
        public RemoteMediaCentersForm(MqttService mqttService)
        {
            InitializeComponent(); 
            _mqttService = mqttService; // Initialise le service MQTT

            // S'abonne à l'événement RemoteMediaCentersChanged pour mettre à jour l'interface utilisateur lorsque la liste des MediaCenters distants change
            _mqttService.RemoteMediaCentersChanged += () =>
            {
                // Vérifie si l'appel doit être invoqué sur le thread de l'interface utilisateur
                if (InvokeRequired)
                    Invoke((Action)UpdateMediaCentersList); // Utilise Invoke pour appeler la méthode de mise à jour sur le thread de l'UI
                else
                    UpdateMediaCentersList();   // Appelle directement la méthode de mise à jour si déjà sur le thread de l'UI
            };
            UpdateMediaCentersList();   // Met à jour la liste des MediaCenters distants au démarrage
        }

        // Met à jour la liste des MediaCenters distants dans l'interface utilisateur
        private void UpdateMediaCentersList()
        {
            listBoxRemote.Items.Clear();    // Efface la liste actuelle
            foreach (var mc in _mqttService.RemoteMediaCenters) // Parcourt chaque MediaCenter distant
            {
                listBoxRemote.Items.Add($"{mc.Name} ({mc.Id})");    // Ajoute le nom et l'ID du MediaCenter à la liste
            }
        }
        // Gère la fermeture du formulaire
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);  // Appelle la méthode de la classe de base

            // Envoie I_AM_OUT pour signaler aux autres que cette médiathèque se déconnecte
            _mqttService.Send(new Envelope(Program.AppMediaCenter.Id, null, MessageType.I_AM_OUT, "Jerry is out")).Wait();  // Le .wait() est utilisé ici pour s'assurer que le message est envoyé avant la fermeture complète
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void goToMediaPage_Click(object sender, EventArgs e)
        {
            MediaLibraryForm f2 = new MediaLibraryForm();   // Crée une nouvelle instance du formulaire MediaLibraryForm
            f2.FormClosed += (s, args) => this.Show();  // Ajoute un gestionnaire d'événements pour afficher à nouveau ce formulaire lorsque f2 est fermé
            this.Hide();    // Cache le formulaire actuel
            f2.Show();  // Affiche le formulaire MediaLibraryForm
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
