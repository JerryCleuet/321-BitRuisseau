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
        MqttService _mqttService;
        public RemoteMediaCentersForm(MqttService mqttService)
        {
            InitializeComponent();
            _mqttService = mqttService;
            _mqttService.RemoteMediaCentersChanged += () =>
            {
                if (InvokeRequired)
                    Invoke((Action)UpdateMediaCentersList);
                else
                    UpdateMediaCentersList();
            };
            UpdateMediaCentersList();
        }



        private void UpdateMediaCentersList()
        {
            listBoxRemote.Items.Clear();
            foreach (var mc in _mqttService.RemoteMediaCenters)
            {
                listBoxRemote.Items.Add($"{mc.Name} ({mc.Id})");
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // Envoie I_AM_OUT pour signaler aux autres que cette médiathèque se déconnecte
            _mqttService.Send(new Envelope(Program.AppMediaCenter.Id, null, MessageType.I_AM_OUT, "")).Wait();
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
