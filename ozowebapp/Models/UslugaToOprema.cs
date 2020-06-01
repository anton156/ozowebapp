using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class UslugaToOprema
    {
        public int UslugaToOpremaID { get; set; }
        public int UslugaClassID { get; set; }
        public int OpremaClassID { get; set; }

        public virtual UslugaClass UslugaClass { get; set; }
        public virtual OpremaClass OpremaClass { get; set; }
    }
}
