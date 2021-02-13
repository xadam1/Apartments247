using AutoMapper;
using BLL.DTOs;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(UserCreateDTO user)
        {
            _unitOfWork.UserRepository.Add(_mapper.Map<User>(user));
        }


        public async Task<User> GetUserAccordingToEmailAsync(string email)
        {
            var query = _unitOfWork.UserQuery.GetUserByEmail(email);
            var result = await query.ExecuteAsync();
            return result.FirstOrDefault();
        }

        public async Task<UserShowDTO> AuthorizeUserAsync(UserLoginDTO login)
        {
            var user = await GetUserAccordingToEmailAsync(login.Email);
            if (user == null)
            {
                return null;
            }

            var (hash, salt) = user != null ? Utils.GetPassAndSalt(user.Password) : (string.Empty, string.Empty);

            var succ = user != null && Utils.VerifyHashedPassword(hash, salt, login.Password);
            return succ ? _mapper.Map<UserShowDTO>(user) : null;
        }

        public void RegisterUser(UserCreateDTO user)
        {
            user.Password = Utils.HashPassword(user.Password);

            Create(user);
        }

        public async Task<IEnumerable<UserIdNameEmailAdminDTO>> GetAllUsersAsync()
        {
            var usersDb = await _unitOfWork.UserRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserIdNameEmailAdminDTO>>(usersDb);
        }

        public async Task<TDto> GetUserAsync<TDto>(int id) 
        {
            var userDb = await _unitOfWork.UserRepository.GetByIdAsync(id);

            return _mapper.Map<TDto>(userDb);
        }

        public HttpStatusCode DeleteUser(int id)
        {
            var taskUser = _unitOfWork.UserRepository.GetByIdAsync(id);
            taskUser.Wait();
            var user = taskUser.Result;
            if (user == null)
            {
                // User doesn't exist in db
                return HttpStatusCode.NoContent;
            }

            _unitOfWork.UserRepository.Delete(taskUser.Result);

            return HttpStatusCode.OK;
        }

        public async Task UpdateUserAsync(int id, UserNamePasswordEmailAdminDTO userDto)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id);
            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.IsAdmin = userDto.IsAdmin;

            if (user.Password != userDto.Password)
            {
                user.Password = Utils.HashPassword(userDto.Password);
            }

            _unitOfWork.UserRepository.Update(user);
        }
    }
}
