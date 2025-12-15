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
using System.Drawing.Text;

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

            MediaLibrary _library = new MediaLibrary();

            // Dossier où sont stockés les médias
            button1.Click += (sender, e) =>
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog()) // Ouvre une fenêtre pour choisir un dossier
                {
                    if (fbd.ShowDialog() == DialogResult.OK) // Si on choisit bien un dossier, passe à la suites
                    {
                        _library.LoadFiles(fbd.SelectedPath);   // Utilisation de la méthode présente dans MediaLibrary pour extraire les métadonnées

                        var displayNames = new List<string>();  // Liste contenant ce qu'on cherche à afficher
                        int mediaBtnIndex = 0;

                        foreach (var file in _library.Medias)
                        {
                            string displayName = $"{file.Title} | {file.Artist} ({file.Year}) {Math.Round((file.Duration.TotalMinutes),2 )} | {file.Size}";   // Format sous lequel je veux afficher mes musiques

                            Button musicBtn = new Button(); // Création et affichage du bouton

                            // Apparence texte
                            musicBtn.Text = displayName;
                            musicBtn.TextAlign = ContentAlignment.MiddleLeft;

                            // Apparence bouton et location
                            musicBtn.Width = 350;
                            int btnTop = 100 + 40 * mediaBtnIndex;
                            musicBtn.Location = new Point(30, btnTop);
                            this.Controls.Add(musicBtn);

                            // Ouverture d'une messageBox quand on clique sur une musique
                            musicBtn.Click += (s, args) =>
                            {
                                MessageBoxMusic box = new MessageBoxMusic(
                                    $"Musique : {file.Title}\nArtiste : {file.Artist}\nAnnée : {file.Year}\nDurée : {file.Duration}\nTaille : {file.Size} KB");
                                box.ShowDialog();
                            };

                            // Bouton pour lancer la musique / la mettre en pause / l'arrêter
                            Button startMusicBtn = new Button();
                            startMusicBtn.Text = "▶";
                            startMusicBtn.Width = 30;
                            startMusicBtn.Location = new Point(400, btnTop);
                            this.Controls.Add(startMusicBtn);


                            startMusicBtn.Click += (s, args) =>
                            {
                                // Correction : suppression de la parenthèse en trop et utilisation du bon chemin
                                axWindowsMediaPlayer1.URL = file.Filepath;
                                axWindowsMediaPlayer1.Ctlcontrols.play();
                            };

                            mediaBtnIndex++;
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
