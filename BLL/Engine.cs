using System;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Infrastructure;
using Infrastructure.Queries;


namespace BLL
{
    public class Engine
    {
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

        public Specification BLLGetSPecificationByGroupID(int groupID)
        {
            int specID = new Repository<UnitGroup>(new ApartmentsDbContext()).GetById(groupID).Result.SpecificationId;
            return new Repository<Specification>(new ApartmentsDbContext()).GetById(specID).Result;
        }

        public void BLLChangeUser(User user)
        {
            new Repository<User>(new ApartmentsDbContext()).Update(user);
        }

        public void BLLChangeSpecification(Specification spec)
        {
            new Repository<Specification>(new ApartmentsDbContext()).Update(spec);
        }

        public (int, string)[] BLLListGroups(int userID)
        {
            return new UnitGroupQuery(new ApartmentsDbContext()).FilterGroupsByUserID(userID).MapGroupsToIDsNames();
        }

        public (int, string)[] BLLListUnitsFromGroup(int groupID)
        {
            return new UnitQuery(new ApartmentsDbContext()).FilterUnitsByGroupID(groupID).MapUnitsToIDsNames();
        }

        /*

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
