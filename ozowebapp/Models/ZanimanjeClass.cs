using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ozowebapp.Models
{
    public class ZanimanjeClass
    {
        public int ZanimanjeClassID { get; set; }
        public string Naziv { get; set; }
        public double? Satnica { get; set; }

        public string? Opis { get; set; }

        public virtual ICollection<DjelatnikClass> Djelatnici { get; set; }
    }
}
