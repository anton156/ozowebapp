using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class NatjecajViewModel
    {
        [Key]
        public int NatjecajClassID { get; set; }
        public string Naziv { get; set; }
        public double Cijena { get; set; }

        public string Opis { get; set; }
        public string Lokacija { get; set; }

        public List<CheckBoxViewModel> Zanimanja { get; set; }
        public List<CheckBoxViewModelOprema> Oprema { get; set; }
    }
}
