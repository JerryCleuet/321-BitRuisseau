using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BitRuisseau
{
    public class Mediatheque
    {
        public string Name {  get; set; }
        public string[] Medias { get; set; }
        public Mediatheque(string name, string[] medias)
        {
            this.Name = name;
            this.Medias = medias;
        }

    }
}
