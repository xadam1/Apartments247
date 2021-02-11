using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface ICostFacade
    {
        Task<List<T>> GetCostsByUnitIdAsync<T>(int id, DateTime fromDate, DateTime toDate);
    }
}
