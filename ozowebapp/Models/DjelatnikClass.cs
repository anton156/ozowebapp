using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class DjelatnikClass
    {
        [Key]
        public int DjelatnikClassID { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Unesite ispravne podatke")]
        public string Prezime { get; set; }

        public int ZanimanjeClassID { get; set; }
        public virtual ZanimanjeClass ZanimanjeClass { get; set; }

        public string? Email { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Datum rođenja")]
        public DateTime? Datum_rodjenja { get; set; }
        

    }
}
