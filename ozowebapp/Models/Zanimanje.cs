using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ozowebapp.Models
{
    public class Zanimanje
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public string Naziv { get; set; }
        [Range(0, 99999, ErrorMessage = "Ne smije")]
        [Required(ErrorMessage = "Ne smije biti prazno")]
        public double? Satnica { get; set; }

        public string? Opis { get; set; }
    }
}
