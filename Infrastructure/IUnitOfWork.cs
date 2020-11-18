using System;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        // Attributes
        IRepository<Address> Address { get; }
        IRepository<Equipment> Equipment { get; }
        IRepository<EquipmentType> EquipmentType { get; }
        IRepository<Specification> Specification { get; }
        IRepository<Unit> Unit { get; }
        IRepository<UnitGroup> UnitGroup { get; }
        IRepository<UnitType> UnitType { get; }
        IRepository<User> User { get; }

        // Methods
        Task CommitAsync();

        // Queries

    }
}