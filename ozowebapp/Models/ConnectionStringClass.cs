using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ozowebapp.Models;

namespace ozowebapp.Models
{
    public class ConnectionStringClass:DbContext
    {
        public ConnectionStringClass(DbContextOptions<ConnectionStringClass> options): base(options)
        {

        }

        public DbSet<OpremaClass> Oprema { get; set; }
        public DbSet<ZanimanjeClass> Zanimanje { get; set; }
        public DbSet<DjelatnikClass> Djelatnik { get; set; }
        public DbSet<UslugaClass> UslugaClass { get; set; }
        public DbSet<UslugaToZanimanje> UslugaToZanimanjes { get; set; }
        public DbSet<UslugaToOprema> UslugaToOpremas { get; set; }
        public DbSet<UslugaViewModel> UslugaViewModel { get; set; }
        public DbSet<PosaoClass> Posao { get; set; }
        public DbSet<PosaoTozanimanje> PosaoToZanimanjes { get; set; }
        public DbSet<PosaoToOprema> PosaoToOpremas { get; set; }


        public DbSet<NatjecajClass> Natjecaj { get; set; }
        public DbSet<NatjecajToZanimanje> NatjecajToZanimanjes { get; set; }
        public DbSet<NatjecajToOprema> NatjecajToOpremas { get; set; }
        public DbSet<NatjecajViewModel> NatjecajViewModels { get; set; }
        public DbSet<ArhivaNatjecajClass> ArhivaNatjecaj { get; set; }
      





    }
}
