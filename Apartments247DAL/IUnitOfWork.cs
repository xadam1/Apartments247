using System;
using ApartmentsDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentsDAL
{
    public interface IUnitOfWork<TDatabase> : IDisposable where TDatabase : DbContext
    {
        // Attributes
        public IRepository<Address> AddressAtr { get; }
        public IRepository<Equipment> EquipmentAtr { get; }
        public IRepository<EquipmentType> EquipmentTypeAtr { get; }
        public IRepository<Specification> SpecificationAtr { get; }
        public IRepository<Unit> UnitAtr { get; }
        public IRepository<UnitGroup> UnitGroupAtr { get; }
        public IRepository<UnitType> UnitTypeAtr { get; }
        public IRepository<User> UserAtr { get; }

        // Methods
        void Complete();
    }
}