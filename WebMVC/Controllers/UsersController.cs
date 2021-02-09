using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.DTOs;
using BLL.Facades;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace WebMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserFacade _userFacade;

        public UsersController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }


        [HttpGet("Register")]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost("Register")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAsync(UserCreateDTO user)
        {
            try
            {
                //TODO Here should be a check for existing user 
                await _userFacade.RegisterUserAsync(user);

                return RedirectToAction("Login", "Users");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Username", "Account with this email already exists!");
                return View("Register");
            }
        }

        [HttpGet("Login")]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LoginAsync(UserLoginDTO userLogin)
        {
            try
            {
                var user = await _userFacade.LoginAsync(userLogin);

                await CreateClaimsAndSignInAsync(user);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                ModelState.AddModelError("Username", "Invalid credentials combination!");
                return View("Login");
            }
        }

        private async Task CreateClaimsAndSignInAsync(UserShowDTO user)
        {
            var claims = new List<Claim>
            {
                //Set User Identity Name to actual user Id - easier access with user connected operations
                new Claim(ClaimTypes.Name, user.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity));
        }
    }
}
