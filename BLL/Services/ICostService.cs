﻿using BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICostService
    {
        Task<List<T>> GetCostsByUnitIdAsync<T>(int id, DateTime fromDate, DateTime toDate);

        void CreateCost<T>(T costDTO);

        Task UpdateCostAsync(int id, CostDTO costDTO);

        void DeleteCost(int id);
    }
}
