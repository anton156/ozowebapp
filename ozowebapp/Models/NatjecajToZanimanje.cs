using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ozowebapp.Models
{
    public class NatjecajToZanimanje
    {
        public int NatjecajToZanimanjeID { get; set; }
        public int NatjecajClassID { get; set; }
        public int ZanimanjeClassID { get; set; }

        public virtual NatjecajClass NatjecajClass { get; set; }
        public virtual ZanimanjeClass ZanimanjeClass { get; set; }
    }
}
