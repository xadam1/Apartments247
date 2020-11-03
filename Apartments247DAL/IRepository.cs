using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();

        TEntity FindFirst(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
