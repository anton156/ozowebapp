using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class DodajDjelatnika
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Prezime { get; set; }

        public string? Zanimanje { get; set; }

        public string? Email { get; set; }
        [Display(Name = "Datum rođenja")]
        [DataType(DataType.Date)]
        public DateTime? Datum_rodjenja { get; set; }
        [Range(0, 99999, ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string? JMBG { get; set; }

        public string? Opis { get; set; }
        public int? Usluga_ID { get; set; }
        public int? Natjecaj_ID { get; set; }
    }
}
