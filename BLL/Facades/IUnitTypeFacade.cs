using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IUnitTypeFacade
    {
        Task<T[]> GetUnitTypesAsync<T>();
    }
}