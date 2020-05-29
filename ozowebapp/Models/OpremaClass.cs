using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class OpremaClass
    {
        public int OpremaClassID { get; set; }
        public string Naziv { get; set; }
        public int? Kolicina { get; set; }
        public double? Cijena { get; set; }
        public double? Duljina_Koristenja_u_h { get; set; }
        
        public string? Lokacija { get; set; }
        public DateTime? Datum_proizvodnje { get; set; }

    }
}
