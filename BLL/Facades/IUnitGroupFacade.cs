using BLL.DTOs;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IUnitGroupFacade
    {
        Task<T[]> GetUnitGroupsByUserIdAsync<T>(int id);

        Task<T[]> GetUnitGroupNamesByUserId<T>(int id);
    }
}
