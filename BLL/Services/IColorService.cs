using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IColorService
    {
        Task<List<T>> GetColorsAsync<T>();
    }
}