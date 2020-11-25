using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Infrastructure.Queries
{
    // Default view of user's unit groups
    public class UnitGroupsWithUsersWithSpecificationsQuery : Query<UnitGroup>
    {
        public UnitGroupsWithUsersWithSpecificationsQuery(ApartmentsDbContext apartmentsDbContext) : base(apartmentsDbContext)
        {
            _query = _query.Include(unitGroup => unitGroup.User);
            _query = _query.Include(unitGroup => unitGroup.Specification);
        }

        public UnitGroupsWithUsersWithSpecificationsQuery FilterByUserId(int userId)
        {
            _query = _query.Where(unitGroup => unitGroup.UserId == userId);
            return this;
        }

        public UnitGroupsWithUsersWithSpecificationsQuery OrderByUnitGroupsName(bool isAscending = true)
        {
            if (isAscending)
            {
                _query = _query.OrderBy(unitGroup => unitGroup.Specification.Name);
            }
            else
            {
                _query = _query.OrderByDescending(unitGroup => unitGroup.Specification.Name);
            }
            return this;
        }
    }
}