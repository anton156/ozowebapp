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
        public DbSet<ozowebapp.Models.UslugaClass> UslugaClass { get; set; }
        public DbSet<ozowebapp.Models.UslugaToZanimanje> UslugaToZanimanjes { get; set; }
        public DbSet<ozowebapp.Models.UslugaViewModel> UslugaViewModel { get; set; }


    }
}
