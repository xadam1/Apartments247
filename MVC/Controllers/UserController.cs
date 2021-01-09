using BLL.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class UserController : Controller
    {
        public UserController()
        {

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(UserNameEmailPassDTO userDto)
        {


            return new EmptyResult();
        }





        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
