using Microsoft.EntityFrameworkCore;
using Parduotuve.Core.Models;
using Parduotuve.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parduotuve.Core.Repositories
{
    public class MyDbContext : DbContext
    {
        public DbSet<Pardavejas> Pardavejai { get; set; }
        public DbSet<Pirkejas> Pirkejai { get; set; }

        public DbSet<Produktas> Produktai { get; set; }
        public DbSet<Uzsakymas> Uzsakymai { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=BaigiamojoDuombaze;Trusted_Connection=True;TrustServerCertificate=true;");
        }



    }
}
