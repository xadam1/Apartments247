using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUnitTypeService
    {
        Task<List<T>> GetUnitTypesAsync<T>();
    }
}