using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IMonthlyCostFacade
    {
        Task<List<T>> GetMonthlyCostsByUnitIdAsync<T>(int id);
    }
}
