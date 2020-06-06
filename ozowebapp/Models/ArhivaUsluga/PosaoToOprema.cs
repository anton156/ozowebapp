using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class PosaoToOprema
    {
        public int PosaoToOpremaID { get; set; }
        public int PosaoClassID { get; set; }
        public int OpremaClassID { get; set; }
        public int Kolicina { get; set; }
        public string Naziv { get; set; }

        public virtual PosaoClass PosaoClass { get; set; }
        public virtual OpremaClass OpremaClass { get; set; }
    }
}
