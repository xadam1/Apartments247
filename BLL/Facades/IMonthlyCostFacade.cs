using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IMonthlyCostFacade
    {
        Task<List<T>> GetMonthlyCostsByUnitIdAsync<T>(int id, DateTime fromDate, DateTime toDate);
    }
}
