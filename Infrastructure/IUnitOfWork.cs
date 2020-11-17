using System;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public interface IUnitOfWork<TDatabase> : IDisposable where TDatabase : DbContext
    {
        // Attributes
        IRepository<Address> AddressAtr { get; }
        IRepository<Equipment> EquipmentAtr { get; }
        IRepository<EquipmentType> EquipmentTypeAtr { get; }
        IRepository<Specification> SpecificationAtr { get; }
        IRepository<Unit> UnitAtr { get; }
        IRepository<UnitGroup> UnitGroupAtr { get; }
        IRepository<UnitType> UnitTypeAtr { get; }
        IRepository<User> UserAtr { get; }

        // Methods
        void Complete();
    }
}