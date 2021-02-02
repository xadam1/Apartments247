using System.Collections.Generic;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUnitGroupService
    {
        Task<List<T>> GetUnitGroupsByUserIdAsync<T>(int id);

        Task<List<T>> GetUnitGroupNamesByUserIdAsync<T>(int id);

        Task<T> GetUnitGroupByIdAsync<T>(int id);

        void CreateUnitGroup(UnitGroupDTO unitGroupDTO);

        Task UpdateUnitGroupAsync(int id, UnitGroupDTO unitGroupDTO);
    }
}
