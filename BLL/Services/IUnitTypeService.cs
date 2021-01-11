using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUnitTypeService
    {
        Task<T[]> GetUnitTypesAsync<T>();
    }
}