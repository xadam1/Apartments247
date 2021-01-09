using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        void Update(TEntity updatedEntity);

        void Delete(TEntity entity);
    }
}
