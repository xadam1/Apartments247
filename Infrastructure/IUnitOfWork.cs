﻿using Infrastructure.Queries;
using System;
using System.Threading.Tasks;
using DAL.Entities;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        // Attributes
        IRepository<Address> AddressRepository { get; }
        IRepository<Equipment> EquipmentRepository { get; }
        IRepository<Specification> SpecificationRepository { get; }
        IRepository<Unit> UnitRepository { get; }
        IRepository<UnitGroup> UnitGroupRepository { get; }
        IRepository<UnitType> UnitTypeRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Color> ColorRepository { get; }
        IRepository<Cost> CostRepository { get; }

        // Methods
        Task CommitAsync();

        // Queries
        UnitGroupsWithUsersWithSpecificationsQuery UnitGroupsWithUsersWithSpecificationsQuery { get; }
        UnitGroupsWithUsersQuery UnitGroupsWithUsersQuery { get; }
        UserQuery UserQuery { get; }
        UsersUnitGroupsWithUnitsQuery UsersUnitGroupsWithUnitsQuery { get; }
        UnitsWithUnitGroupsQuery UnitsWithUnitGroupsQuery { get; }
        CostQuery CostQuery { get; }
        EquipmentQuery EquipmentQuery { get; }
    }
}