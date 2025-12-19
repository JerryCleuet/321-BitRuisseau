using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau.Models
{
    public class MediaLibrary
    {
        public string FolderPath { get; set; }
        public List<Media> Medias { get; set; } = new List<Media>();


        public void LoadFiles(string path)
        {
            string folderpath = path;
            Medias.Clear();
            var files = Directory.GetFiles(path);

            foreach (var file in files)
            {
                var tagFile = TagLib.File.Create(file); // Utilisation de la librairie TagLib pour récupérer les métadonnées des fichiers audio

                var media = new Media(
                    tagFile.Tag?.Title ?? "",
                    tagFile.Tag?.FirstArtist ?? "",
                    tagFile.Tag?.Year.ToString() ?? "",
                    tagFile.Properties.Duration,
                    new FileInfo(file).Length / 1024,   // Récupération de la taille du fichier, en KB (d'où le / 1024)
                    tagFile.Tag?.JoinedPerformers ?? ""
                );
                media.Filepath = file;
                Medias.Add(media);
            }
        }
    }
}
