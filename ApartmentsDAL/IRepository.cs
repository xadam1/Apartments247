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
    }


    public class UnitOfWork<DatabaseType>
    {
        public DatabaseType Database { get; }

        // Tables
        public Repository<Address> Address { get; private set; } = new Repository<Address>(Database);
        public Repository<Equipment> equipment { get; private set; } = new Repository<Equipment>(databaseP);
        public Repository<EquipmentType> equipmentType { get; private set; } = new Repository<EquipmentType>(databaseP);
        public Repository<Specification> specification { get; private set; } = new Repository<Specification>(databaseP);
        public Repository<Unit> unit { get; private set; } = new Repository<Unit>(databaseP);
        public Repository<UnitGroup> unitGroup { get; private set; } = new Repository<UnitGroup>(databaseP);
        public Repository<UnitType> UnitType { get; private set; }
        public Repository<User> UserAtr { get; private set; }

        // Constructor
        public UnitOfWork(DatabaseType databaseP)
        {
            Database = databaseP;

            // Inicialization
            UserAtr = new Repository<User>(databaseP);
        }
    }
}
