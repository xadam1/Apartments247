using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApartmentsDbContext _dbContext;
        
        // Tables
        public IRepository<Address> Address { get; }
        public IRepository<Equipment> Equipment { get; }
        public IRepository<EquipmentType> EquipmentType { get; }
        public IRepository<Specification> Specification { get; }
        public IRepository<Unit> Unit { get; }
        public IRepository<UnitGroup> UnitGroup { get; }
        public IRepository<UnitType> UnitType { get; }
        public IRepository<User> User { get; }
        
        // Constructor
        public UnitOfWork()
        {
            _dbContext = new ApartmentsDbContext();

            // Initialization
            Address = new Repository<Address>(_dbContext);
            Equipment = new Repository<Equipment>(_dbContext);
            EquipmentType = new Repository<EquipmentType>(_dbContext);
            Specification = new Repository<Specification>(_dbContext);
            Unit = new Repository<Unit>(_dbContext);
            UnitGroup = new Repository<UnitGroup>(_dbContext);
            UnitType = new Repository<UnitType>(_dbContext);
            User = new Repository<User>(_dbContext);
        }


        public async Task CommitAsync() 
            => await _dbContext.SaveChangesAsync();

        
        public void Dispose() 
            => _dbContext.Dispose();
    }
}