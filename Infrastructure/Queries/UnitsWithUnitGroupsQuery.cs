using DAL;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DAL.Entities;

namespace Infrastructure.Queries
{
    public class UnitsWithUnitGroupsQuery : Query<Unit>
    {
        public UnitsWithUnitGroupsQuery(ApartmentsDbContext apartmentsDbContext) : base(apartmentsDbContext)
        {
            _query = _query.Include(unit => unit.UnitGroup);
        }

        public UnitsWithUnitGroupsQuery FilterByUnitGroupId(int unitGroupId)
        {
            _query = _query.Where(unit => unit.UnitGroupId == unitGroupId);
            return this;
        }
    }
}