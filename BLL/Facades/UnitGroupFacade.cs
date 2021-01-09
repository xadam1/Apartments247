using BLL.Services;
using Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using BLL.DTOs;

namespace BLL.Facades
{
    public class UnitGroupFacade : IUnitGroupFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserService _userService;

        public UnitGroupFacade(IUnitOfWork unitOfWork, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _userService = userService;
        }

        /*public Task<Dictionary<UnitGroupNameDto, List<UnitNameDto>>> GetAllUsersUnitGroupsWithUnits()
        {
            return new Dictionary<UnitGroupNameDto, List<UnitNameDto>>;
        }*/
    }
}
