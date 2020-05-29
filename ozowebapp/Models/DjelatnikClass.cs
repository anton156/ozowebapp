using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class DjelatnikClass
    {
        public int DjelatnikClassID { get; set; }
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public int ZanimanjeClassID { get; set; }
        public virtual ZanimanjeClass ZanimanjeClass { get; set; }

        public string? Email { get; set; }
        public DateTime? Datum_rodjenja { get; set; }
        

    }
}
