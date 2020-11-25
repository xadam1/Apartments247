using System;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Infrastructure;


namespace BLL
{
    public class Engine
    {
        public void Test()
        {
            using (var dbContext = new ApartmentsDbContext())
            {
                var tomci = dbContext.Users.FirstOrDefault(x=>x.Username=="Hotentot");
                Console.WriteLine($"name: {tomci?.Username}\npass: {tomci?.Password}");
            }

            Console.ReadKey();
        }

        public bool BLLCreateAccount(string name, string password, string email)
        {
            if (!new UserQuery(new ApartmentsDbContext()).UserWithNameExists(name))
            {
                new Repository<User>(new ApartmentsDbContext())
                    .Add(new User() { Username = name, Password = password, Email = email, IsAdmin = false });
                return true;
            }
            return false;
        }


        public (bool, int) BLLGetUserIDByCredentials(string name, string password)
        {
            User user = new UserQuery(new ApartmentsDbContext()).GetUserByCredentials(name, password).GetFirst();
            return (user != null, user != null ? user.Id : 0);
        }

        public User GetUserByID(int userID)
        {
            return new Repository<User>(new ApartmentsDbContext()).GetById(userID).Result;
        }

        public void BLLChangeUser(User user)
        {
            new Repository<User>(new ApartmentsDbContext()).Update(user);
        }

        /*

        public DAL.Models.User[] BLLGetAllUsers()
        {
            return database.DALGetAllUsers();
        }

        public string[] BLLListGroups(DAL.Models.User user)
        {
            return database.DALListGroups(user);
        }

        public DAL.Models.UnitGroup BLLGetGroupByID(int group)
        {
            return database.DALGetGroupByID(group);
        }

        public void BLLChangeGroup(DAL.Models.UnitGroup unitGroup)
        {
            database.DALChangeGroup(unitGroup);
        }

        public DAL.Models.Unit BLLGetUnitByID(int unit)
        {
            return database.DALGetUnitByID(unit);
        }

        public void BLLChangeUnit(DAL.Models.Unit unit)
        {
            database.DALChangeUnit(unit);
        }
        */
    }
}
