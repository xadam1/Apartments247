using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Facades;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserFacade _userFacade;

        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IEnumerable<UserIdNameEmailAdminDTO>> GetAllUsers()
        {
            return await _userFacade.GetAllUsersAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<UserIdNameEmailAdminDTO> GetUser(int id)
        {
            return await _userFacade.GetUserAsync<UserIdNameEmailAdminDTO>(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async void Post(string username, string password, string email)
        {
            var userDto = new UserCreateDTO()
            {
                Username = username,
                Password = password,
                Email = email
            };

            //TODO check valid input

            await _userFacade.RegisterUserAsync(userDto);
        }

        // PUT api/<UsersController>/5/false
        [HttpPut("{userToBeChangedId}/{newIsAdmin}")]
        public void Put(int userToBeChangedId, string newUsername, string newPassword, string newEmail, bool newIsAdmin=false)
        {
            var userTask = _userFacade.GetUserAsync<UserNamePasswordEmailAdminDTO>(userToBeChangedId);
            userTask.Wait();

            var user = userTask.Result;

            if (!string.IsNullOrEmpty(newUsername))
            {
                user.Username = newUsername;
            }

            if (!string.IsNullOrEmpty(newPassword))
            {
                user.Password = newPassword;
            }

            if (!string.IsNullOrEmpty(newEmail))
            {
                user.Email = newEmail;
            }

            if (user.IsAdmin != newIsAdmin)
            {
                user.IsAdmin = newIsAdmin;
            }

            //TODO check valid input

            _userFacade.UpdateUserAsync(userToBeChangedId, user).Wait();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public HttpStatusCode Delete(int id)
        {
            return _userFacade.DeleteUser(id);
        }
    }
}
