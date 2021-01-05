using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IUserService
    {
        void Create(UserCreateDTO user);

        Task<UserShowDTO> GetUserAccordingToEmailAsync(string name);

        Task<UserShowDTO> AuthorizeUserAsync(UserLoginDTO login);

        void RegisterUser(UserCreateDTO user);
    }
}
