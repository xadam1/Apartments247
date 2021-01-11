using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IColorFacade
    {
        Task<T[]> GetColorsAsync<T>();
    }
}
