using AutoMapper;
using BLL.DTOs;
using DAL.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private const int PBKDF2IterCount = 100000;
        private const int PBKDF2SubkeyLength = 160 / 8;
        private const int saltSize = 128 / 8;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Create(UserCreateDTO user)
        {
            _unitOfWork.UserRepository.Add(_mapper.Map<User>(user));
        }


        public async Task<UserShowDTO> GetUserAccordingToEmailAsync(string email)
        {
            //TODO
            /*
             var query = _unitOfWork.UserQuery.GetUserByEmail(email);
            var result = await query.ExecuteAsync();
            var user = result.First();
            return _mapper.Map<UserShowDTO>(user);
            */
            throw new NotImplementedException();
        }

        public async Task<UserShowDTO> AuthorizeUserAsync(UserLoginDTO login)
        {
            var userDto = await GetUserAccordingToEmailAsync(login.Email);
            if (userDto == null)
            {
                return null;
            }

            //get user entity
            var user = await _unitOfWork.UserRepository.GetByIdAsync(userDto.Id);

            var (hash, salt) = user != null ? GetPassAndSalt(user.Password) : (string.Empty, string.Empty);

            var succ = user != null && VerifyHashedPassword(hash, salt, login.Password);
            return succ ? userDto : null;
        }

        public void RegisterUser(UserCreateDTO user)
        {
            var (hash, salt) = CreateHash(user.Password);
            user.Password = string.Join(',', hash, salt);

            Create(user);
        }

        private (string, string) GetPassAndSalt(string passwordHash)
        {
            var result = passwordHash.Split(',');
            if (result.Count() != 2)
            {
                return (string.Empty, string.Empty);
            }
            return (result[0], result[1]);
        }

        private bool VerifyHashedPassword(string hashedPassword, string salt, string password)
        {
            var hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            var saltBytes = Convert.FromBase64String(salt);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes, PBKDF2IterCount))
            {
                var generatedSubkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);
                return hashedPasswordBytes.SequenceEqual(generatedSubkey);
            }
        }

        private Tuple<string, string> CreateHash(string password)
        {
            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltSize, PBKDF2IterCount))
            {
                byte[] salt = deriveBytes.Salt;
                byte[] subkey = deriveBytes.GetBytes(PBKDF2SubkeyLength);

                return Tuple.Create(Convert.ToBase64String(subkey), Convert.ToBase64String(salt));
            }
        }

        public async Task<IEnumerable<UserNameEmailAdminDTO>> GetAllUsersAsync()
        {
            var usersDb = await _unitOfWork.UserRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserNameEmailAdminDTO>>(usersDb);
        }

        public async Task<UserNameEmailAdminDTO> GetUserAsync(int id)
        {
            var userDb = await _unitOfWork.UserRepository.GetByIdAsync(id);

            return _mapper.Map<UserNameEmailAdminDTO>(userDb);
        }
    }
}
