using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApartmentsDbContext : DbContext
    {
        private readonly Dictionary<string, string> _connections = new Dictionary<string, string>()
        {
            {"localDb", @"data source=(localdb)\MSSQLLocalDB; initial catalog=ApartmentsDB; integrated security=SSPI"},
            {"sharedServer", @"Data Source=cassiopeia.serveirc.com\SQLEXPRESS,1433; Initial Catalog = ApartmentsDB; Integrated Security = FALSE; User ID = Apartments247; password=Janči-je-naprostý-Somár"}
        };

        private readonly string _connectionString;

        public ApartmentsDbContext()
        {
            _connectionString = _connections["sharedServer"];
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
