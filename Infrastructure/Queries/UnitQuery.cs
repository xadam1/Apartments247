using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DAL.Models;
using DAL;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Queries
{
    public class UnitQuery : Query<Unit>
    {
        public UnitQuery(ApartmentsDbContext context) : base(context) { }
        public UnitQuery(IQueryable<Unit> query)
        {
            _query = query;
        }

        public UnitQuery FilterUnitsByGroupID(int groupID)
        {
            //_query = _query.Where(unit => unit.UnitGroupId == groupID);
            return this;
        }

        public (int, string)[] MapUnitsToIDsNames()
        {
            return _query.ToArray().Select(unit => (unit.Id, unit.Specification.Name)).ToArray();
        }
    }
}
