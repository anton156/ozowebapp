using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ozowebapp.Models
{
    public class ConnectionStringClass:DbContext
    {
        public ConnectionStringClass(DbContextOptions<ConnectionStringClass> options): base(options)
        {

        }

        public DbSet<Oprema> Oprema { get; set; }
        public DbSet<Zanimanje> Zanimanje { get; set; }
        public DbSet<Djelatnik> Djelatnik { get; set; }
    }
}
