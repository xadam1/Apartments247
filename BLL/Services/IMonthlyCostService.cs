using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IMonthlyCostService
    {
        Task<List<T>> GetMonthlyCostsByUnitIdAsync<T>(int id, DateTime fromDate, DateTime toDate);
    }
}
