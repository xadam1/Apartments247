using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IUnitTypeFacade
    {
        Task<List<T>> GetUnitTypesAsync<T>();
    }
}