using BLL.DTOs;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        void Create(UserCreateDTO user);

        Task<UserShowDTO> AuthorizeUserAsync(UserLoginDTO login);

        void RegisterUser(UserCreateDTO user);

        Task<IEnumerable<UserIdNameEmailAdminDTO>> GetAllUsersAsync();

        Task<TDto> GetUserAsync<TDto>(int id);

        HttpStatusCode DeleteUser(int id);

        Task UpdateUserAsync(int id, UserNamePasswordEmailAdminDTO userDto);
    }
}
