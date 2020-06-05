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
        [Key]
        public int OpremaClassID { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        public string Naziv { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        [Range(0,99999999)]
        public int Kolicina { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        [Range(0, 99999999)]
        public double? Cijena { get; set; }
        [Required(ErrorMessage ="Unesite ispravne podatke")]
        [Range(0, 99999999)]
        [Display(Name ="Duljina korištenja u h")]
        public double? Duljina_Koristenja_u_h { get; set; }
        
        public string? Lokacija { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Datum proizvodnje")]
        public DateTime? Datum_proizvodnje { get; set; }

        public virtual List<UslugaToOprema> UslugaToOpremas { get; set; }

    }
}
