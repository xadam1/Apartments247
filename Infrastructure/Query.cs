﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class Query<TEntity> where TEntity : BaseEntity
    {
        protected IQueryable<TEntity> _query;

        // Constructor
        public Query(ApartmentsDbContext dbContext)
        {
            _query = dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> ExecuteAsync()
            => await _query?.ToListAsync() ?? new List<TEntity>();

        public void Page(int pageSize, int pageNumber)
        {
            //we count pages from 1
            _query.Skip(pageSize * (pageNumber - 1))
                  .Take(pageSize);
        }
    }
}