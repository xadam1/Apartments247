using DAL;
using DAL.Models;
using Infrastructure;
using Infrastructure.Queries;
using DAL.Extras;


namespace BLL
{
    public class Engine
    {
        public (bool, int) BLLGetUserIDByCredentials(string name, string password)
        {
            User user = new UserQuery(new ApartmentsDbContext()).GetUserByCredentials(name, password).GetFirst();
            return (user != null, user != null ? user.Id : 0);
        }

        public Specification BLLGetSPecificationByGroupID(int groupID)
        {
            int specID = new Repository<UnitGroup>(new ApartmentsDbContext()).GetById(groupID).Result.SpecificationId;
            return new Repository<Specification>(new ApartmentsDbContext()).GetById(specID).Result;
        }
        public int BLLGetSpecificationIDByGroupID(int groupID)
        {
            return BLLGetSPecificationByGroupID(groupID).Id;
        }

        public (int, string)[] BLLListGroups(int userID)
        {
            return new UnitGroupQuery(new ApartmentsDbContext()).FilterGroupsByUserID(userID).MapGroupsToIDsNames();
        }

        public (int, string)[] BLLListUnitsFromGroup(int groupID)
        {
            return new UnitQuery(new ApartmentsDbContext()).FilterUnitsByGroupID(groupID).MapUnitsToIDsNames();
        }

        public int BLLGetAddressIDByGroupID(int groupID)
        {
            int specID = new Repository<UnitGroup>(new ApartmentsDbContext()).GetById(groupID).Result.SpecificationId;
            return BLLGetAddressIDBySpecificationID(specID);
        }

        public int BLLGetAddressIDBySpecificationID(int specID)
        {
            return new Repository<Specification>(new ApartmentsDbContext()).GetById(specID).Result.AddressId;
        }

        public (bool, UnitType) BLLGetTypeByName(string typeName)
        {
            UnitType type = new UnitTypeQuery(new ApartmentsDbContext()).FilterByName(typeName).GetFirst();
            return (type != null, type);
        }

        public int BLLGetAddressIDByUnitID(int unitID)
        {
            return new Repository<Unit>(new ApartmentsDbContext()).GetById(unitID).Result.Specification.AddressId;
        }

        #region CreateDbSet
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

        public void BLLCreateUnit(int curCapacity, int maxCapacity, string name, Color color, string note, int typeID, int unitGroupID)
        {
            int addressID = new Repository<UnitGroup>(new ApartmentsDbContext()).GetById(unitGroupID).Result.Specification.AddressId;
            Specification spec = new Specification() { Name = name, Color = color, Note = note, AddressId = addressID };
            new Repository<Specification>(new ApartmentsDbContext()).Add(spec);
            Unit unit = new Unit() { CurrentCapacity = curCapacity, MaxCapacity = maxCapacity, UnitTypeId = typeID, SpecificationId = spec.Id, UnitGroupId = unitGroupID };
            new Repository<Unit>(new ApartmentsDbContext()).Add(unit);
        }

        public void BLLCreateGroup(string name, Color color, string note, int userID, string state, string city, string street, string number, string zip)
        {
            Address address = new Address() { State = state, City = city, Street = street, Number = number, Zip = zip };
            new Repository<Address>(new ApartmentsDbContext()).Add(address);
            Specification spec = new Specification() { Name = name, Color = color, Note = note, AddressId = address.Id };
            new Repository<Specification>(new ApartmentsDbContext()).Add(spec);
            UnitGroup group = new UnitGroup() { SpecificationId = spec.Id, UserId = userID};
            new Repository<UnitGroup>(new ApartmentsDbContext()).Add(group);
        }
        #endregion

        #region GetDbSetById
        public Unit BLLGetUnitByID(int unitID)
        {
            return new Repository<Unit>(new ApartmentsDbContext()).GetById(unitID).Result;
        }

        public Address BLLGetAddressByID(int addressID)
        {
            return new Repository<Address>(new ApartmentsDbContext()).GetById(addressID).Result;
        }

        public User GetUserByID(int userID)
        {
            return new Repository<User>(new ApartmentsDbContext()).GetById(userID).Result;
        }

        public Specification BLLGetSpecificationByID(int specID)
        {
            return new Repository<Specification>(new ApartmentsDbContext()).GetById(specID).Result;
        }

        public UnitGroup BLLGetGroupByID(int groupID)
        {
            return new Repository<UnitGroup>(new ApartmentsDbContext()).GetById(groupID).Result;
        }
        #endregion

        #region ChangeDbSet
        public void BLLChangeUnit(Unit unit)
        {
            new Repository<Unit>(new ApartmentsDbContext()).Update(unit);
        }

        public void BLLChangeAddress(Address address)
        {
            new Repository<Address>(new ApartmentsDbContext()).Update(address);
        }

        public void BLLChangeSpecification(Specification spec)
        {
            new Repository<Specification>(new ApartmentsDbContext()).Update(spec);
        }

        public void BLLChangeUser(User user)
        {
            new Repository<User>(new ApartmentsDbContext()).Update(user);
        }
        #endregion
    }
}
