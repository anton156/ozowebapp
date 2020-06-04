using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class UslugaToZanimanje
    {
        public int UslugaToZanimanjeID { get; set; }
        public int UslugaClassID { get; set; }
        public int ZanimanjeClassID { get; set; }

        public int Kolicina { get; set; }
        public string Naziv { get; set; }
        public virtual UslugaClass UslugaClass { get; set; }
        public virtual ZanimanjeClass ZanimanjeClass { get; set; }
    }
}
