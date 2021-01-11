using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUnitGroupService
    {
        Task<T[]> GetUnitGroupsByUserIdAsync<T>(int id);

        Task<T[]> GetUnitGroupNamesByUserIdAsync<T>(int id);

        Task<T> GetUnitGroupByIdAsync<T>(int id);
    }
}
