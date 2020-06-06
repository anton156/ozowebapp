using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class ArhivaNatjecajToZanimanje
    {
        public int ArhivaNatjecajToZanimanjeID { get; set; }
        public int ArhivaNatjecajClassID { get; set; }
        public int ZanimanjeClassID { get; set; }

        public int Kolicina { get; set; }
        public string Naziv { get; set; }

        public virtual ArhivaNatjecajClass ArhivaNatjecajClass { get; set; }
        public virtual ZanimanjeClass ZanimanjeClass { get; set; }
    }
}
