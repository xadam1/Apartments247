using DAL;
using DAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Queries
{
    public class UnitQuery : Query<Unit>
    {
        public UnitQuery(ApartmentsDbContext context) : base(context) { }

        //TODO Vojta
        /*public UnitQuery FilterUnitsByGroupID(int groupID)
        {
            //_query = _query.Where(unit => unit.UnitGroups.Any(ug => ug.Specification.Id == groupID));
            _query = _query.Where(unit => unit.UnitGroup.Specification.Id == groupID);
            return this;
        }*/

        public List<(int, string)> MapUnitsToIDsNames()
        {
            return _query.ToList().Select(unit => (unit.Id, unit.Specification.Name)).ToList();
        }
    }
}
