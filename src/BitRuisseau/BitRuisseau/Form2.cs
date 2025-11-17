using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitRuisseau
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            mediaPageTitle.Text = "Liste des pistes audio disponibles";
            GoToMediatequesPage.Text = "Liste des médiathèques";

            string mediaPath = Path.Combine(Environment.CurrentDirectory, "medias");


            if (!Directory.Exists(mediaPath))
            {
                return;
            }

            var medias = Directory.GetFiles(mediaPath);
            var mediaNames = new List<string>();

            foreach (var mediasFile in medias)
            {

                var firstLine = File.ReadLines(mediasFile).FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(firstLine))
                    mediaNames.Add(firstLine);
                else
                    mediaNames.Add(Path.GetFileName(mediasFile));
            }
            mediaList.Text = String.Join("\n",mediaNames);
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GoToMediatequesPage_Click(object sender, EventArgs e)
        {
            var f1 = new Form1();
            f1.FormClosed += (s, args) => this.Show();
            this.Hide();
            f1.Show();
        }

        private void mediaList_Click(object sender, EventArgs e)
        {

        }
    }
}
