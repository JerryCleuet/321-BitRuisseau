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
using BitRuisseau.Models;
using BitRuisseau.Protocol;
using BitRuisseau.Services;

namespace BitRuisseau
{
    public partial class MediaLibraryForm : Form
    {
        List<MediaCenter> _remoteMediaCenters = new List<MediaCenter>();

        public MediaLibraryForm()
        {
            InitializeComponent();
            mediaPageTitle.Text = "Liste des pistes audio disponibles";
            GoToMediatequesPage.Text = "Liste des médiathèques";
            IntroText.Text = $"Voici la liste des médias disponibles dans le dossier choisi";

            ShowMusicList();
        }


        public void ShowMusicList()
        {
            MediaLibrary _library = new MediaLibrary();

            // Si on clique sur le bouton, on peut choisir le dossier de médias
            button1.Click += (sender, e) =>
            {
                // Ouvre une fenêtre pour choisir le dossier
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        // Utilise une méthode pour charger les médias, avec la bonne syntaxe
                        LoadAndDisplay(fbd.SelectedPath, _library);
                    }
                    else
                    {
                        MessageBox.Show("Aucun dossier sélectionné.");
                    }
                }
            };
        }
        private void LoadAndDisplay(string path, MediaLibrary _library)
        {
            _library.LoadFiles(path);

            // Nettoyage de l’affichage précédent
            this.Controls
                .OfType<Button>()   // Si le type est button
                .Where(b => b.Tag?.ToString() == "music")   // Si le tag est music
                .ToList()
                .ForEach(b => this.Controls.Remove(b)); // Supprimer les boutons précédents

            int mediaBtnIndex = 0;

            foreach (Media file in _library.Medias)
            {
                // Syntaxe des musiques
                string displayName =
                    $"{file.Title} | {file.Artist} ({file.Year}) " +
                    $"{Math.Round(file.Duration.TotalMinutes, 2)} min | {file.Size} KB";

                int btnTop = 100 + 40 * mediaBtnIndex;

                // Bouton musique
                Button musicBtn = new Button
                {
                    Text = displayName,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Width = 350,
                    Location = new Point(30, btnTop),
                    Tag = "music"
                };

                // Box qui s'affiche si on appuie sur un son
                musicBtn.Click += (s, args) =>
                {
                    MessageBoxMusic box = new MessageBoxMusic(
                        $"Musique : {file.Title}\n" +
                        $"Artiste : {file.Artist}\n" +
                        $"Année : {file.Year}\n" +
                        $"Durée : {file.Duration}\n" +
                        $"Taille : {file.Size} KB");
                    box.ShowDialog();
                };

                this.Controls.Add(musicBtn);

                // Bouton lecture
                Button startMusicBtn = new Button
                {
                    Text = "▶",
                    Width = 30,
                    Location = new Point(400, btnTop),
                    Tag = "music"
                };

                startMusicBtn.Click += (s, args) =>
                {
                    axWindowsMediaPlayer1.URL = file.Filepath;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                };

                this.Controls.Add(startMusicBtn);

                mediaBtnIndex++;
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void GoToMediatequesPage_Click(object sender, EventArgs e)
        {
            // Création de Form1
            RemoteMediaCentersForm f1 = new RemoteMediaCentersForm(_remoteMediaCenters);
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
