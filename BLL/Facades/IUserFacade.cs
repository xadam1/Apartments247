using BLL.DTOs;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public interface IUserFacade
    {
        Task<UserShowDTO> LoginAsync(UserLoginDTO userLogin);

        Task RegisterUserAsync(UserCreateDTO user);

        Task<IEnumerable<UserIdNameEmailAdminDTO>> GetAllUsersAsync();

        Task<TDto> GetUserAsync<TDto>(int id);

        HttpStatusCode DeleteUser(int id);

        Task UpdateUserAsync(int id, UserNamePasswordEmailAdminDTO userDto);
    }
}
