using System;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        // Attributes
        IRepository<Address> AddressRepository { get; }
        IRepository<Equipment> EquipmentRepository { get; }
        IRepository<EquipmentType> EquipmentTypeRepository { get; }
        IRepository<Specification> SpecificationRepository { get; }
        IRepository<Unit> UnitRepository { get; }
        IRepository<UnitGroup> UnitGroupRepository { get; }
        IRepository<UnitType> UnitTypeRepository { get; }
        IRepository<User> UserRepository { get; }

        // Methods
        Task CommitAsync();

        // Queries
        UnitGroupsWithUsersWithSpecificationsQuery UnitGroupsWithUsersWithSpecificationsQuery { get; }
    }
}