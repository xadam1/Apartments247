using BLL.DTOs;
using BLL.Facades;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserFacade _userFacade;

        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(UserCreateDTO userDto)
        {
            // todo check infa
            await _userFacade.RegisterUserAsync(userDto);
            return new EmptyResult();
        }





        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
