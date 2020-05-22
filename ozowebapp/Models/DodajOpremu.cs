using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class DodajOpremu
    {
        public int ID { get; set; }
        [Required(ErrorMessage="Ne smije biti prazno")]
        public string Naziv { get; set; }
        [Range(0, 99999,ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public int Kolicina { get; set; }
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public float Cijena { get; set; }
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public float Duljina_Koristenja_u_h { get; set; }
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Lokacija { get; set; }
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Datum_proizvodnje { get; set; }
        
        public int Usluga_ID { get; set; }
        public int Natjecaj_ID { get; set; }

    }
}
