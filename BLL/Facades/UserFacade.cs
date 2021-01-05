using BLL.Services;
using Infrastructure;
using System;
using System.Threading.Tasks;

namespace BLL.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UserFacade(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        public async Task<UserShowDTO> LoginAsync(UserLoginDTO userLogin)
        {
            var user = await _userService.AuthorizeUserAsync(userLogin);
            if (user != null)
            {
                return user;
            }

            throw new UnauthorizedAccessException();
        }

        public async Task RegisterUserAsync(UserCreateDTO user)
        {
            _userService.RegisterUser(user);
            await _unitOfWork.CommitAsync();
        }
    }
}
