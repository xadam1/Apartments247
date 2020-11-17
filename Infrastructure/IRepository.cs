using System;
using System.Linq.Expressions;

namespace Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
