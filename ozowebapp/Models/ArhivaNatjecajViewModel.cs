using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class ArhivaNatjecajViewModel
    {
        [Key]
        public int ArhivaNatjecajClassID { get; set; }
        public string? Pobjednik { get; set; }
        public string? Zakljucak { get; set; }
    }
}
