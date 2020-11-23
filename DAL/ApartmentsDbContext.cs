using System.Security.Cryptography.X509Certificates;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System;

namespace DAL
{
    public class ApartmentsDbContext : DbContext
    {
        // Rozbitá relativní reference na System.Configuration.dll byla nahrazena správným zahrnutím System.Configuration 4.7.0
        private string CONNECTION_STRING = ConfigurationManager.ConnectionStrings[0].ConnectionString;
        public ApartmentsDbContext()
        {
            throw new Exception();
            //Database.SetInitializer
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<UnitGroup> UnitGroups { get; set; }

        public DbSet<UnitType> UnitTypes { get; set; }

        public DbSet<Specification> Specifications { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(CONNECTION_STRING);
            //.UseLazyLoadingProxies();
        }
    }
}
