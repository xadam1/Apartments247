using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DAL;

namespace BLL
{
    public class Engine
    {
        
        private Database database = new Database();
        public (bool, DAL.Models.User) BLLGetUserByCredentials(string name, string password)
        {
            return database.DALGetUserByCredentials(name, password);
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
    }
}
