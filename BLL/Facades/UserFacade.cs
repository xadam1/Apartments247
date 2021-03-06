﻿using BLL.DTOs;
using BLL.Services;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Net;
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

        public HttpStatusCode DeleteUser(int id)
        {
            var httpStatusCode = _userService.DeleteUser(id);

            _unitOfWork.CommitAsync().Wait();

            return httpStatusCode;
        }

        public async Task<IEnumerable<UserIdNameEmailAdminDTO>> GetAllUsersAsync()
        {
            return await _userService.GetAllUsersAsync();
        }

        public async Task<TDto> GetUserAsync<TDto>(int id)
        {
            return await _userService.GetUserAsync<TDto>(id);
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

        public async Task UpdateUserAsync(int id, UserNamePasswordEmailAdminDTO userDto)
        {
            await _userService.UpdateUserAsync(id, userDto);
            await _unitOfWork.CommitAsync();
        }
    }
}
