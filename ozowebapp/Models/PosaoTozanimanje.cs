using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class PosaoTozanimanje
    {
        public int PosaoTozanimanjeID { get; set; }
        public int PosaoClassID { get; set; }
        public int ZanimanjeClassID { get; set; }

        public int Kolicina { get; set; }
        public string Naziv { get; set; }
        public virtual PosaoClass PosaoClass { get; set; }
        public virtual ZanimanjeClass ZanimanjeClass { get; set; }
    }
}
