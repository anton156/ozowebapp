using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class DodajOpremu
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage="Ne smije biti prazno")]
        public string Naziv { get; set; }
        [Range(0, 99999,ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public int? Kolicina { get; set; }
        [Range(0, 99999, ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public double? Cijena { get; set; }
        [Display(Name ="Duljina korištenja u h")]
        [Range(0, 99999, ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public double? Duljina_Koristenja_u_h { get; set; }
        
        public string? Lokacija { get; set; }
        [Display(Name ="Datum proizvodnje")]
        [DataType(DataType.Date)]
        public DateTime? Datum_proizvodnje { get; set; }
        
        public int? Usluga_ID { get; set; }
        public int? Natjecaj_ID { get; set; }

    }
}
