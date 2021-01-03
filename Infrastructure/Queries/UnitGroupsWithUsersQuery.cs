using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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