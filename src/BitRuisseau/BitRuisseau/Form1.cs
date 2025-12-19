using BitRuisseau.Protocol;
using Microsoft.VisualBasic.Devices;
using System.Drawing.Text;
using System.Text.Json;

namespace BitRuisseau
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Chemin du dossier des médias
            string path = Path.Combine(Environment.CurrentDirectory, "medias"); ;
            MainTitle.Text = "Liste des médiathèques";
            goToMediaPage.Text = "Liste des médias";
            
                
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void goToMediaPage_Click(object sender, EventArgs e)
        {
            var f2 = new Form2();
            f2.FormClosed += (s, args) => this.Show();
            this.Hide();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
