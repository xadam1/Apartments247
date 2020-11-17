using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }
        

        public TEntity GetById(int id)
            => Context.Set<TEntity>().Find(id);


        public void Add(TEntity entity)
            => Context.Set<TEntity>().Add(entity);


        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
            => Context.Set<TEntity>().Where(predicate).First();


        public void Update(TEntity entity)
        {
            Context.Set<TEntity>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }


        public void Remove(TEntity entity)
            => Context.Set<TEntity>().Remove(entity);
    }
}