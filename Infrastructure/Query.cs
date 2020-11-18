using System.Linq;
using DAL;
usign DAL.Models;

namespace Infrastructure
{
    public class Query<TEntity> where TEntity : BaseEntity
    {
        protected IQueryable<TEntity> _query;

        // Constructor
        public Query(ApartmentsDbContext dbContext)
        {
            _query = dbContext.Set<TEntity>();
        }
    }
}