using System;

namespace ApartmentsDAL
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        void Create(TEntity entity);
        
        TEntity Retrieve(int id);

        void Update(TEntity entity);

        void Delete(int id);
    }
}