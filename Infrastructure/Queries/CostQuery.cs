using DAL;
using DAL.Models;
using System;
using System.Linq;

namespace Infrastructure.Queries
{
    public class CostQuery : Query<Cost>
    {
        public CostQuery(ApartmentsDbContext apartmentsDbContext) : base(apartmentsDbContext)
        {
        }

        public CostQuery FilterByUnitId(int unitId)
        {
            _query = _query.Where(cost => cost.UnitId == unitId);
            return this;
        }

        public CostQuery FilterByDate(DateTime fromDate, DateTime toDate)
        {
            _query = _query.Where(cost => fromDate <= cost.Date && cost.Date <= toDate);
            return this;
        }
    }
}