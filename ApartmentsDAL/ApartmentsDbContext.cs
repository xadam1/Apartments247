using Microsoft.EntityFrameworkCore;
using ApartmentsDAL.Models;

namespace ApartmentsDAL
{
    class ApartmentsDbContext : DbContext
    {
        private string ConnectionString = "(localdb)\\MSSQLLocalDB;IntegratedSecurity = True; MultipleActiveResultSets=True;Database=ApartmentsDB;Trusted_Connection=True;";

        public DbSet<User> Users { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<UnitGroup> UnitGroups { get; set; }

        public DbSet<UnitType> UnitTypes { get; set; }

        public DbSet<Specification> Specifications { get; set; }

        public DbSet<Equipment> Equipment { get; set; }

        public DbSet<EquipmentType> EquipmentTypes { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString)
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO EDIT
            base.OnModelCreating(modelBuilder);
        }
    }
}
