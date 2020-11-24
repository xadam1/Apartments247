using System.Configuration;
using Castle.DynamicProxy.Generators.Emitters;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class ApartmentsDbContext : DbContext
    {
        private readonly string _connectionString;


        public ApartmentsDbContext()
        {
            // "data source=(localdb)\MSSQLLocalDB; initial catalog=ApartmentsDB; integrated security=SSPI"
            _connectionString =
                @"data source=(localdb)\MSSQLLocalDB; initial catalog=ApartmentsDB; integrated security=SSPI";
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
            optionsBuilder.UseSqlServer(_connectionString)
            .UseLazyLoadingProxies();
        }
    }
}
