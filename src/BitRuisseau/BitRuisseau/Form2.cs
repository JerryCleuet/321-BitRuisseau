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
            IntroText.Text = $"Voici la liste des médias disponibles dans le dossier choisi";

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
                            var tagFile = TagLib.File.Create(file); // Utilisation de la librairie TagLib# pour lire les métadonnées des fichiers audio
                            string title = tagFile.Tag?.Title ?? "";
                            string artist = tagFile.Tag?.FirstArtist ?? "";
                            string year = tagFile.Tag?.Year.ToString() ?? "";
                            string duration = tagFile.Properties.Duration.ToString(@"mm\:ss") ?? "";
                            string size = (new FileInfo(file).Length / 1024).ToString() + " KB" ?? ""; // Taille du fichier en KB
                            string featuring = tagFile.Tag?.JoinedPerformers ?? "";

                            var media = new Media(title, artist, year, duration, size, featuring);    // Instanciation d'un nouvel objet Media
                            mediaObjects.Add(media);    // Ajout de l'objet à la liste des médias

                            string displayName = $"{media.Title} | {media.Artist} ({media.Year})                           {media.Duration} | {media.Size}";   // Format sous lequel je veux afficher mes musiques

                            displayNames.Add(displayName);  // Ajout de la musique sous son bon format
                            Button musicBtn = new Button(); // Création et affichage du bouton
                            // Apparence texte
                            musicBtn.Text = displayName;
                            musicBtn.TextAlign = ContentAlignment.MiddleLeft;
                            // Apparence bouton et location
                            musicBtn.Width = 350;
                            int btnTop = 100 + 40 * displayNames.Count;
                            musicBtn.Location = new Point(30, btnTop);
                            this.Controls.Add(musicBtn);

                            // Ouverture d'une messageBox quand on clique sur une musique
                            musicBtn.Click += (s, args) =>
                            {
                                MessageBoxMusic box = new MessageBoxMusic(
                                    $"Musique : {media.Title}\nArtiste : {media.Artist}\nAnnée : {media.Year}\nDurée : {media.Duration}\nTaille : {media.Size}"
                                );
                                box.ShowDialog();
                            };

                        }
                    }
                    else
                    {
                        MessageBox.Show("Aucun dossier sélectionné.");
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
