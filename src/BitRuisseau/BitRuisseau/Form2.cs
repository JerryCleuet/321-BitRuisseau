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
            IntroText.Text = "Voici la liste des médias disponibles dans le dossier /médias ";

            // Dossier où sont stockés les médias
            button1.Click += (sender, e) =>
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog()) // Ouvre une fenêtre pour choisir un dossier
                {
                    if (fbd.ShowDialog() == DialogResult.OK) // Si on choisit bien un dossier, passe à la suites
                    {
                        var medias = Directory.GetFiles(fbd.SelectedPath); // Fichiers récupérés dans le dossier choisi

                        var mediaObjects = new List<Media>();           // Liste d'objets Media
                        var displayNames = new List<string>();          // Liste contenant ce qu'on cherche à afficher

                        foreach (var file in medias)
                        {
                            try
                            {
                                FileInfo infos = new FileInfo(file);
                                var lines = File.ReadAllLines(file);

                                // Propriétés de Media
                                string title = "";
                                string artist = "";
                                string year = "";
                                string duration = "";
                                long size = infos.Length;
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

                                var media = new Media(title, artist, year, duration, size, featuring);    // Instanciation d'un nouvel objet Media
                                mediaObjects.Add(media);    // Ajout de l'objet à la liste des médias

                                string displayName = $"{media.Title} | {media.Artist} ({media.Year})                           {media.Duration} | {media.Size}";   // Format sous lequel je veux afficher mes musiques

                                displayNames.Add(displayName); // Ajout de la musique sous son bon format
                                                               // Création et affichage du bouton
                                Button musicBtn = new Button();
                                // Apparence texte
                                musicBtn.Text = displayName;
                                musicBtn.TextAlign = ContentAlignment.MiddleLeft;
                                // Apparence bouton et location
                                musicBtn.Width = 350;
                                int btnTop = 100 + 40 * displayNames.Count;
                                musicBtn.Location = new Point(30, btnTop);
                                this.Controls.Add(musicBtn);

                                // Ouverture d'une messageBox quand on clique sur une musique
                                musicBtn.Click += (sender, e) =>
                                {
                                    MessageBoxMusic box = new MessageBoxMusic($"Musique : {media.Title}\nArtiste : {media.Artist}\nAnnée : {media.Year}\nDurée : {media.Duration}\nTaille : {media.Size}");
                                    box.ShowDialog();
                                };
                            }
                            catch
                            {
                                displayNames.Add(Path.GetFileName(file));
                            }
                        }



                    }
                }

            };
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GoToMediatequesPage_Click(object sender, EventArgs e)
        {
            // Ouverture de Form1
            var f1 = new Form1();
            f1.FormClosed += (s, args) => this.Show();
            // Cacher Form2
            this.Hide();
            // Montrer Form1
            f1.Show();
        }

        private void IntroText_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
