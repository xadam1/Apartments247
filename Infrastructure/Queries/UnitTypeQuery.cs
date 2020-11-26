using System;
using System.Collections.Generic;
using System.Text;
using DAL.Models;
using Infrastructure;
using DAL;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Infrastructure.Queries
{
    public class UnitTypeQuery : Query<UnitType>
    {
        public UnitTypeQuery(IQueryable<UnitType> query)
        {
            _query = query;
        }
        public UnitTypeQuery(ApartmentsDbContext context) : base(context) { }
        public UnitTypeQuery FilterByName(string name)
        {
            return new UnitTypeQuery(_query.Where(type => type.Type == name));
        }
    }
}
