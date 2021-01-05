using DAL.Extras;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ApartmentsDbContext : DbContext
    {
        private readonly Dictionary<string, string> _connections = new Dictionary<string, string>()
        {
            { "localDb", @"data source=(localdb)\MSSQLLocalDB; initial catalog=ApartmentsDB; integrated security=SSPI" },
            { "sharedServer", @"Data Source=cassiopeia.serveirc.com\SQLEXPRESS,1433; Initial Catalog = ApartmentsDB; Integrated Security = FALSE; User ID = Apartments247; password=Janči-je-naprostý-Somár" }
        };

        private readonly string _connectionString;

        public ApartmentsDbContext()
        {
            _connectionString = _connections["localDb"];
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<UnitGroup> UnitGroups { get; set; }

        public DbSet<UnitType> UnitTypes { get; set; }

        public DbSet<Specification> Specifications { get; set; }

        public DbSet<Equipment> Equipment { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString)
            .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Specification
            modelBuilder.Entity<Specification>()
                .HasOne(specification => specification.Address)
                .WithOne()
                .HasForeignKey<Specification>(specification => specification.AddressId);


            // Unit
            modelBuilder.Entity<Unit>()
                .HasOne(unit => unit.UnitType)
                .WithMany(unitType => unitType.Units)
                .HasForeignKey(unit => unit.UnitTypeId);

            modelBuilder.Entity<Unit>()
                .HasMany(unit => unit.AvailableEquipment)
                .WithMany(equipment => equipment.Units)
                .UsingEntity(j => j.ToTable("UnitEquipment"));


            // UnitGroup
            modelBuilder.Entity<UnitGroup>()
                .HasOne(unitGroup => unitGroup.User)
                .WithMany(user => user.UnitGroups)
                .HasForeignKey(unitGroup => unitGroup.UserId);

            modelBuilder.Entity<UnitGroup>()
                .HasOne(unitGroup => unitGroup.Specification)
                .WithOne()
                .HasForeignKey<UnitGroup>(unitGroup => unitGroup.SpecificationId);

            modelBuilder.Entity<UnitGroup>()
                .HasMany(unitGroup => unitGroup.Units)
                .WithMany(unitGroup => unitGroup.UnitGroups);


            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            //TODO Vojta
            //modelBuilder.Seed();
        }
    }
}
