using BLL.DTOs;
using BLL.Facades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IEnumerable<UserNameEmailAdminDTO>> GetAllUsers()
        {
            return await _userFacade.GetAllUsersAsync();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<UserNameEmailAdminDTO> GetUser(int id)
        {
            return await _userFacade.GetUserAsync(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        /*
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }*/

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
