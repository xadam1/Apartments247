using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> 
        where TEntity : class
    {
        private readonly ApartmentsDbContext _context;

        public Repository(ApartmentsDbContext context)
        {
            _context = context;
        }

        #region IRepository Methods

        public void Add(TEntity entity)
        {  
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }
                
        public async Task<TEntity> GetByIdAsync(int id) 
            => await _context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _context.Set<TEntity>().ToListAsync();

        public void Update(TEntity updatedEntity)
        {
            _context.Set<TEntity>().Attach(updatedEntity);
            _context.Entry(updatedEntity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
            => _context.Set<TEntity>().Remove(entity);

        #endregion
        
        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
            => _context.Set<TEntity>().Where(predicate).First();
    }
}