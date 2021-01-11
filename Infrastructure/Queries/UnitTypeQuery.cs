using DAL;
using DAL.Models;
using System.Linq;

namespace Infrastructure.Queries
{
    public class UnitTypeQuery : Query<UnitType>
    {
        public UnitTypeQuery(ApartmentsDbContext context) : base(context) { }

        public UnitTypeQuery FilterByName(string name)
        {
            _query = _query.Where(type => type.Type == name);
            return this;
        }
    }
}
