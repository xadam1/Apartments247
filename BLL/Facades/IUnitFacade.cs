using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IUnitFacade
    {
        Task<T[]> GetUnitsByGroupIdAsync<T>(int id);

        Task<T> GetUnitByIdAsync<T>(int id);
    }
}
