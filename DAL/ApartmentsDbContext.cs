﻿using DAL.Extras;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL
{
    public class ApartmentsDbContext : DbContext
    {
        private readonly string _connectionString;

        public ApartmentsDbContext()
        {
            _connectionString = ConnectionStrings.DB_CONN_STRING;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<UnitGroup> UnitGroups { get; set; }

        public DbSet<UnitType> UnitTypes { get; set; }

        public DbSet<Specification> Specifications { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<Color> Colors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=../Database/ApartmentsDB.db")
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


            // MonthlyCost
            modelBuilder.Entity<MonthlyCost>()
                .HasOne(monthlyCost => monthlyCost.Unit)
                .WithMany(unit => unit.MonthlyCosts)
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
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }


            modelBuilder.Entity<Unit>()
                .HasOne(u => u.UnitGroup)
                .WithMany(ug => ug.Units)
                .HasForeignKey(u => u.UnitGroupId);

            modelBuilder.Seed();
        }
    }
}
