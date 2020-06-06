using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class NatjecajToOprema
    {
        public int NatjecajToOpremaID { get; set; }
        public int NatjecajClassID { get; set; }
        public int OpremaClassID { get; set; }

        public int Kolicina { get; set; }
        public string Naziv { get; set; }

        public virtual NatjecajClass UslugaClass { get; set; }
        public virtual OpremaClass OpremaClass { get; set; }
    }
}
