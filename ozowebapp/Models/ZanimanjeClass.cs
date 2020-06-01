using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ozowebapp.Models
{
    public class ZanimanjeClass
    {
        [Key]
        public int ZanimanjeClassID { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        [Range(0,99999999)]
        public double? Satnica { get; set; }

        public string? Opis { get; set; }
        public int? Kolicina { get; set; }

        public virtual ICollection<DjelatnikClass> Djelatnici { get; set; }
        public virtual List<UslugaToZanimanje> UslugaToZanimanjes { get; set; }
    }
}
