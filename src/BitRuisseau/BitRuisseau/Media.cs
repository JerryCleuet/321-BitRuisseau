using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public class Media
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Year { get; set; }
        public string Duration { get; set; }
        public string Size { get; set; }
        public string? Featuring { get; set; }

        public Media(string title, string artist, string year, string duration, string size, string featuring)
        {
            this.Title = title;
            this.Artist = artist;
            this.Year = year;
            this.Duration = duration;
            this.Size = Size;
            this.Featuring = featuring;

        }
    }
}
