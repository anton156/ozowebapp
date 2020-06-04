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
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        [Range(0, 99999999)]
        public double Cijena { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]

        public string Opis { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        public string Lokacija { get; set; }
        public virtual List<NatjecajToZanimanje> NatjecajToZanimanjes { get; set; }
        public virtual List<NatjecajToOprema> NatjecajToOpremas { get; set; }
    }
}
