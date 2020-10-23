using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ApartmentsDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ApartmentsDAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }


    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id)
            => Context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll()
            => Context.Set<TEntity>().ToList();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().Where(predicate);

        public void Add(TEntity entity)
            => Context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AddRange(entities);

        public void Remove(TEntity entity)
            => Context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().RemoveRange(entities);
    }


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

        public void Complete() => Database.SaveChanges();

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
