using DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.Entities;

namespace Infrastructure.Queries
{
    public class UnitGroupsWithUsersQuery : Query<UnitGroup>
    {
        public UnitGroupsWithUsersQuery(ApartmentsDbContext apartmentsDbContext) : base(apartmentsDbContext)
        {
            _query = _query.Include(unitGroup => unitGroup.User);
        }

        public UnitGroupsWithUsersQuery FilterByUserId(int userId)
        {
            _query = _query.Where(unitGroup => unitGroup.UserId == userId);
            return this;
        }
    }
}