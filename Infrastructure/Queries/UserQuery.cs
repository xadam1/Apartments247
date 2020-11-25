using System.Linq;
using DAL;
using DAL.Models;

namespace Infrastructure.Queries
{
    public class UserQuery : Query<User>
    {
        public UserQuery(ApartmentsDbContext dbContext) : base(dbContext) { }

        public UserQuery(IQueryable<User> query)
        {
            _query = query;
        }

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