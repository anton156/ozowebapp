using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class PosaoClass
    {
        [Key]
        public int PosaoClassID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }

        public string Opis { get; set; }
        public string Lokacija { get; set; }

        public DateTime Datum_pocetak { get; set; }
        public DateTime? Datum_kraj { get; set; }

        public int UslugaClassID { get; set; }

        public virtual List<PosaoTozanimanje> PosaoToZanimanjes { get; set; }
        public virtual List<PosaoToOprema> PosaoToOpremas { get; set; }
    }
}
