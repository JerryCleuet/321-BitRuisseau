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
        public string Id { get; init; } = Guid.NewGuid().ToString();

        public string Name { get; set; }
        public Mediatheque(string id, string name )
        {
            this.Name = name;
            this.Id = id;
        }

    }
}
