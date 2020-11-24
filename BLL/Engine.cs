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

        /*
        //private Database database = new Database();
        public async Task<User> BLLGetUserByCredentials(string name, string password)
        {
            
        }

        public DAL.Models.User[] BLLGetAllUsers()
        {
            return database.DALGetAllUsers();
        }

        public bool BLLCreateAccount(string name, string password, string email)
        {
            return database.DALCreateAccount(name, password, email);
        }

        public void BLLChangeUser(DAL.Models.User user)
        {
            database.DALChangeUser(user);
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
