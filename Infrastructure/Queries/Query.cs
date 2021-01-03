using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class Query<TEntity> where TEntity : BaseEntity
    {
        protected IQueryable<TEntity> _query;

        public Query(ApartmentsDbContext dbContext)
        {
            _query = dbContext.Set<TEntity>();
        }
        
        public async Task<IEnumerable<TEntity>> ExecuteAsync()
        {
            return await _query?.ToListAsync() ?? new List<TEntity>();
        }

        public void Page(int pageSize, int pageNumber)
        {   //we count pages from 1
            _query = _query.Skip(pageSize * (pageNumber - 1))
                           .Take(pageSize);
        }

        public TEntity GetFirst()
        {
            return _query.FirstOrDefault();
        }
    }
}