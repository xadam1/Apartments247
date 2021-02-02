using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IColorFacade
    {
        Task<List<T>> GetColorsAsync<T>();
    }
}
