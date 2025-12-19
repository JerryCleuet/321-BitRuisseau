using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BitRuisseau.Models
{
    public class Media
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Year { get; set; }
        public TimeSpan Duration { get; set; }
        public long Size { get; set; }
        public string? Featuring { get; set; }

        // Ignorer le FilePath quand on fait les échanges P2P
        [JsonIgnore]
        public string? Filepath { get; set; }

        public Media(string title, string artist, string year, TimeSpan duration, long size, string featuring)
        {
            Title = title;
            Artist = artist;
            Year = year;
            Duration = duration;
            Size = size;
            Featuring = featuring;
        }
    }
}
