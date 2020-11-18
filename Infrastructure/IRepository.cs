using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        Task<TEntity> Get(int id);

        void Update(TEntity updatedEntity);

        void Delete(TEntity entity);
    }
}
