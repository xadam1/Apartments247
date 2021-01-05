using System.Linq;
using DAL;
using DAL.Models;

namespace Infrastructure.Queries
{
    public class UserQuery : Query<User>
    {
        public UserQuery(ApartmentsDbContext dbContext) : base(dbContext) { }

        public UserQuery GetAllUsers()
        {
            return this;
        }

        public UserQuery GetUserByName(string name)
        {
            _query = _query.Where(user => user.Username == name);
            return this;
        }

        public UserQuery GetUserByPassword(string password)
        {
            _query = _query.Where(user => user.Password == password);
            return this;
        }

        public UserQuery GetUserByEmail(string email)
        {
            _query = _query.Where(user => user.Email == email);
            return this;
        }

        public UserQuery GetUserByCredentials(string name, string password)
        {
            GetUserByName(name).GetUserByPassword(password);
            return this;
        }

        public bool UserWithNameExists(string name)
        {
            return GetUserByName(name)._query.Count() != 0;
        }
    }
}