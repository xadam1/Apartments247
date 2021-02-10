using DAL;
using DAL.Models;
using System.Linq;

namespace Infrastructure.Queries
{
    public class MonthlyCostsQuery : Query<MonthlyCost>
    {
        public MonthlyCostsQuery(ApartmentsDbContext apartmentsDbContext) : base(apartmentsDbContext)
        {
        }

        public MonthlyCostsQuery FilterByUnitId(int unitId)
        {
            _query = _query.Where(cost => cost.UnitId == unitId);
            return this;
        }
    }
}