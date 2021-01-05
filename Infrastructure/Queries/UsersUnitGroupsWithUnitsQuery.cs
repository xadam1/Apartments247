using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Queries
{
    public class UsersUnitGroupsWithUnitsQuery : Query<UnitGroup>
    {
        public UsersUnitGroupsWithUnitsQuery(ApartmentsDbContext apartmentsDbContext) : base(apartmentsDbContext)
        {
            _query = _query.Include(unitGroup => unitGroup.User);
            _query = _query.Include(unitGroup => unitGroup.Units);
        }

        public UsersUnitGroupsWithUnitsQuery FilterUnitGroupsByUserId(int userId)
        {
            _query = _query.Where(unitGroup => unitGroup.UserId == userId);
            return this;
        }
    }
}