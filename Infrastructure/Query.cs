using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

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

        public Query(IQueryable<TEntity> query)
        {
            _query = query;
        }

        public async Task<IEnumerable<TEntity>> ExecuteAsync()
            => await _query?.ToListAsync() ?? new List<TEntity>();

        public void Page(int pageSize, int pageNumber)
        {
            //we count pages from 1
            _query.Skip(pageSize * (pageNumber - 1))
                  .Take(pageSize);
        }

        public TEntity GetFirst()
        {
            return _query.FirstOrDefault();
        }
    }

    public class UserQuery : Query<User>
    {
        public UserQuery(ApartmentsDbContext dbContext) : base(dbContext) { }
        public UserQuery(IQueryable<User> query) : base(query) { }

        public UserQuery GetUserByName(string name)
        {
            return new UserQuery(_query.Where(user => user.Username == name));
        }

        public UserQuery GetUserByPassword(string password)
        {
            return new UserQuery(_query.Where(user => user.Password == password));
        }

        public UserQuery GetUserByCredentials(string name, string password)
        {
            return GetUserByName(name).GetUserByPassword(password);
        }

        public bool UserWithNameExists(string name)
        {
            return GetUserByName(name)._query.Count() != 0;
        }
    }
}