using DAL.Extras;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.Entities;

namespace DAL
{
    public class ApartmentsDbContext : DbContext
    {
        public ApartmentsDbContext()
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Contract> Contracts { get; set; }

        public DbSet<Cost> Costs { get; set; }

        public DbSet<Equipment> Equipments { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Specification> Specifications { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<UnitGroup> UnitGroups { get; set; }

        public DbSet<UnitType> UnitTypes { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionStrings.DB_CONN_STRING)
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
                .HasMany(unit => unit.Photos)
                .WithOne()
                .HasForeignKey(photo => photo.UnitId);

            modelBuilder.Entity<Unit>()
                .HasOne(u => u.UnitGroup)
                .WithMany(ug => ug.Units)
                .HasForeignKey(u => u.UnitGroupId);


            // UnitEquipment
            modelBuilder.Entity<UnitEquipment>()
                .HasOne(unitEquipment => unitEquipment.Unit)
                .WithMany(unit => unit.UnitEquipments)
                .HasForeignKey(unitEquipment => unitEquipment.UnitId);

            modelBuilder.Entity<UnitEquipment>()
                .HasOne(unitEquipment => unitEquipment.Equipment)
                .WithMany(equipment => equipment.UnitEquipments)
                .HasForeignKey(unitEquipment => unitEquipment.EquipmentId);


            // Photo
            modelBuilder.Entity<Photo>()
                .HasOne(photo => photo.Unit)
                .WithMany(unit => unit.Photos)
                .HasForeignKey(photo => photo.UnitId);


            // Cost
            modelBuilder.Entity<Cost>()
                .HasOne(monthlyCost => monthlyCost.Unit)
                .WithMany(unit => unit.Costs)
                .HasForeignKey(monthlyCost => monthlyCost.UnitId);


            // UnitGroup
            modelBuilder.Entity<UnitGroup>()
                .HasOne(unitGroup => unitGroup.User)
                .WithMany(user => user.UnitGroups)
                .HasForeignKey(unitGroup => unitGroup.UserId);

            modelBuilder.Entity<UnitGroup>()
                .HasOne(unitGroup => unitGroup.Specification)
                .WithOne()
                .HasForeignKey<UnitGroup>(unitGroup => unitGroup.SpecificationId);


            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Cascade;
            }

            modelBuilder.Seed();
        }
    }
}
