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


            var medias = Directory.GetFiles(mediaPath);     // Fichiers récupérés dans /medias
            var mediaObjects = new List<Media>();           // Liste d'objets Media
            var displayNames = new List<string>();          // Liste contenant ce qu'on cherche à afficher

            foreach (var file in medias)
            {
                try
                {
                    var lines = File.ReadAllLines(file);

                    // Propriétés de Media
                    string title = "";
                    string artist = "";
                    string year = "";
                    string duration = "";
                    string featuring = "";

                    // Pour chaque propriété de Media, on prend une ligne différente (dépendamment de l'organisation du fichier)
                    if (lines.Length > 0)
                        title = lines[0];

                    if (lines.Length > 1)
                        artist = lines[1];

                    if (lines.Length > 2)
                        year = lines[2];

                    if (lines.Length > 3)
                        duration = lines[3];

                    if (lines.Length > 4)
                        featuring = lines[4];

                    var media = new Media(title, artist, year, duration, featuring);    // Instanciation d'un nouvel objet Media
                    mediaObjects.Add(media);    // Ajout de l'objet à la liste des médias

                    string displayName = $"{media.Title} - {media.Duration} | {media.Artist} ({media.Year})";   // Format sous lequel je veux afficher mes musiques

                    displayNames.Add(displayName); // Ajout de la musique sous son bon format
                }
                catch
                {
                    displayNames.Add(Path.GetFileName(file));
                }

            }
            // Affichage des médias avec le label mediaList
            mediaList.Text = string.Join("\n", displayNames);
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

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
