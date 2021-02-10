﻿using DAL;
using DAL.Models;
using Infrastructure.Queries;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApartmentsDbContext _dbContext;

        // Tables
        public IRepository<Address> AddressRepository { get; }
        public IRepository<Equipment> EquipmentRepository { get; }
        public IRepository<Specification> SpecificationRepository { get; }
        public IRepository<Unit> UnitRepository { get; }
        public IRepository<UnitGroup> UnitGroupRepository { get; }
        public IRepository<UnitType> UnitTypeRepository { get; }
        public IRepository<User> UserRepository { get; }
        public IRepository<Color> ColorRepository { get; }
        public IRepository<MonthlyCost> MonthlyCostRepository { get; }


        // Queries
        public UnitGroupsWithUsersWithSpecificationsQuery UnitGroupsWithUsersWithSpecificationsQuery { get; }
        public UnitGroupsWithUsersQuery UnitGroupsWithUsersQuery { get; }
        public UserQuery UserQuery { get; }
        public UsersUnitGroupsWithUnitsQuery UsersUnitGroupsWithUnitsQuery { get; }
        public UnitsWithUnitGroupsQuery UnitsWithUnitGroupsQuery { get; }
        public MonthlyCostsQuery MonthlyCostsQuery { get; }


        // Constructor
        public UnitOfWork()
        {
            _dbContext = new ApartmentsDbContext();

            // Initialization
            AddressRepository = new Repository<Address>(_dbContext);
            EquipmentRepository = new Repository<Equipment>(_dbContext);
            SpecificationRepository = new Repository<Specification>(_dbContext);
            UnitRepository = new Repository<Unit>(_dbContext);
            UnitGroupRepository = new Repository<UnitGroup>(_dbContext);
            UnitTypeRepository = new Repository<UnitType>(_dbContext);
            UserRepository = new Repository<User>(_dbContext);
            ColorRepository = new Repository<Color>(_dbContext);
            MonthlyCostRepository = new Repository<MonthlyCost>(_dbContext);

            UnitGroupsWithUsersWithSpecificationsQuery = new UnitGroupsWithUsersWithSpecificationsQuery(_dbContext);
            UnitGroupsWithUsersQuery = new UnitGroupsWithUsersQuery(_dbContext);
            UserQuery = new UserQuery(_dbContext);
            UsersUnitGroupsWithUnitsQuery = new UsersUnitGroupsWithUnitsQuery(_dbContext);
            UnitsWithUnitGroupsQuery = new UnitsWithUnitGroupsQuery(_dbContext);
            MonthlyCostsQuery = new MonthlyCostsQuery(_dbContext);
        }


        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}