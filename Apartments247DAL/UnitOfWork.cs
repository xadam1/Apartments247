using ApartmentsDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentsDAL
{
    public class UnitOfWork<TDatabase> : IUnitOfWork<TDatabase> where TDatabase : DbContext
    {
        public TDatabase Database { get; }

        // Tables
        public IRepository<Address> AddressAtr { get; }
        public IRepository<Equipment> EquipmentAtr { get; }
        public IRepository<EquipmentType> EquipmentTypeAtr { get; }
        public IRepository<Specification> SpecificationAtr { get; }
        public IRepository<Unit> UnitAtr { get; }
        public IRepository<UnitGroup> UnitGroupAtr { get; }
        public IRepository<UnitType> UnitTypeAtr { get; }
        public IRepository<User> UserAtr { get; }

        public void Complete() 
            => Database.SaveChanges();

        // Constructor
        public UnitOfWork(TDatabase databaseP)
        {
            Database = databaseP;

            // Initialization
            AddressAtr = new Repository<Address>(Database);
            EquipmentAtr = new Repository<Equipment>(Database);
            EquipmentTypeAtr = new Repository<EquipmentType>(Database);
            SpecificationAtr = new Repository<Specification>(Database);
            UnitAtr = new Repository<Unit>(Database);
            UnitGroupAtr = new Repository<UnitGroup>(Database);
            UnitTypeAtr = new Repository<UnitType>(Database);
            UserAtr = new Repository<User>(Database);
        }

        public void Dispose() => Database.Dispose();
    }
}