using BitRuisseau.Protocol;
using BitRuisseau.Services;

namespace BitRuisseau
{
    public partial class RemoteMediaCentersForm : Form
    {
        MqttService _mqttService;
        MediaCenter _mediaCenter;
        public RemoteMediaCentersForm(IReadOnlyCollection<MediaCenter> mediaCenters)
        {
            InitializeComponent();
            foreach (MediaCenter mediaCenter in mediaCenters)
            {
                listBoxRemote.Items.Add($"{mediaCenter.Name}({mediaCenter.Id})");
            }
            _mediaCenter = new MediaCenter()
            {
                Name = "Jerry"
            };
            _mqttService = new MqttService(_mediaCenter);
            StartMqtt();
        }
        private async void StartMqtt()
        {
            try
            {
                await _mqttService.StartAsync();
            }
            catch (Exception ex)
            {
                // do not crash the UI if MQTT fails to start
                MessageBox.Show($"Impossible de démarrer le service MQTT : {ex.Message}", "Erreur MQTT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void goToMediaPage_Click(object sender, EventArgs e)
        {
            MediaLibraryForm f2 = new MediaLibraryForm();
            f2.FormClosed += (s, args) => this.Show();
            this.Hide();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
