using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IUnitGroupFacade
    {
        Task<T[]> GetUnitGroupsByUserIdAsync<T>(int id);

        Task<T[]> GetUnitGroupNamesByUserId<T>(int id);

        Task<T> GetUnitGroupByIdAsync<T>(int id);

        Task CreateUnitGroupAsync(UnitGroupDTO unitGroupDTO);

        Task UpdateUnitGroupAsync(int id, UnitGroupDTO unitGroupDTO);
    }
}
