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

        Task<IEnumerable<UserNameEmailAdminDTO>> GetAllUsersAsync();

        Task<UserNameEmailAdminDTO> GetUserAsync(int id);

        HttpStatusCode DeleteUser(int id);
    }
}
