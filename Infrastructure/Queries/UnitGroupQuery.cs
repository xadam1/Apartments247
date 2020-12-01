﻿using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DAL.Models;
using System.Linq;

namespace Infrastructure.Queries
{
    public class UnitGroupQuery : Query<UnitGroup>
    {
        public UnitGroupQuery(IQueryable<UnitGroup> query)
        {
            _query = query;
        }

        public UnitGroupQuery(ApartmentsDbContext context) : base(context) { }

        public UnitGroupQuery FilterGroupsByUserID(int userID)
        {
            _query = _query.Where(group => group.UserId == userID);
            return this;
        }

        public (int, string)[] MapGroupsToIDsNames()
        {
            return _query.ToArray().Select(group => (group.Id, group.Specification.Name)).ToArray();
        }
    }
}
