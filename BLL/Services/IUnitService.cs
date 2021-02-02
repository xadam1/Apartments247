using System.Collections.Generic;
using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUnitService
    {
        Task<List<T>> GetUnitsByGroupIdAsync<T>(int id);

        Task<T> GetUnitByIdAsync<T>(int id);

        void CreateUnit(UnitDTO unitDTO);

        Task UpdateUnitAsync(int id, UnitDTO unitDTO);
    }
}
