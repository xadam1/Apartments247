using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IColorService
    {
        Task<T[]> GetColorsAsync<T>();
    }
}