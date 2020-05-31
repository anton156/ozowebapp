using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class UslugaViewModel
    {
        [Key]
        public int UslugaClassID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }

        public string Opis { get; set; }
        public string Lokacija { get; set; }

        public List<CheckBoxViewModel> Zanimanja { get; set; }
    }
}
