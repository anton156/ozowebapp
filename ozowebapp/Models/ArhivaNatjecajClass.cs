using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class ArhivaNatjecajClass
    {
        [Key]
        public int ArhivaNatjecajClassID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }

        public string Opis { get; set; }
        public string Lokacija { get; set; }
        public string? Pobjednik { get; set; }
        public string? Zakljucak { get; set; }

        public int NatjecajClassID { get; set; }
    }
}
