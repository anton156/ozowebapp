using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class NatjecajClass
    {
        [Key]
        public int NatjecajClassID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }

        public string Opis { get; set; }
        public string Lokacija { get; set; }
        public virtual List<NatjecajToZanimanje> NatjecajToZanimanjes { get; set; }
        public virtual List<NatjecajToOprema> NatjecajToOpremas { get; set; }
    }
}
