using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTemp1.Models;


namespace TestTemp1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Catergory> Catergory { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }

        public DbSet<PBWCellType> PBWCellType { get; set; }

        public DbSet<PBWGagingSt> PBWGagingSt { get; set; }
    }


    
}
