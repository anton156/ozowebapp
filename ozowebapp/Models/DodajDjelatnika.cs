using System;
using System.ComponentModel.DataAnnotations;

namespace ozowebapp.Models
{
    public class DodajDjelatnika
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Ime { get; set; }
        [Range(0, 99999, ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Prezime { get; set; }
        [Range(0, 99999, ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Zanimanje { get; set; }
        [Range(0, 99999, ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Email { get; set; }
        public DateTime Datum_rodjenja { get; set; }
        public int JMBG { get; set; }
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Opis { get; set; }
        public int Usluga_ID { get; set; }
        public int Natjecaj_ID { get; set; }
    }
}