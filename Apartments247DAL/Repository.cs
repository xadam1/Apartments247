using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }


        #region GetMethods
        public TEntity GetById(int id)
            => Context.Set<TEntity>().Find(id);

        public IEnumerable<TEntity> GetAll()
            => Context.Set<TEntity>().ToList();
        #endregion


        #region FindMethods
        public TEntity FindFirst(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().Where(predicate).First();

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().Where(predicate);
        #endregion


        #region AddMethods
        public void Add(TEntity entity)
            => Context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().AddRange(entities);
        #endregion


        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }


        #region RemoveMethods
        public void Remove(TEntity entity)
            => Context.Set<TEntity>().Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities)
            => Context.Set<TEntity>().RemoveRange(entities);
        #endregion
    }
}