using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using CorveTool.DAL.Models;
using CorveTool.DAL.Repositories;
using CorveTool.Models;
using CorveTool.DAL.Context;

namespace CorveTool.Controllers
{
    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        private IRepository<Users> UserRepository { get; set; }
        public AccountController(IRepository<Users> userRepository)
        {
            UserRepository = userRepository; 
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            var redirectUrl = Url.Action(nameof(HomeController.Index), "Home");
            return Challenge(
                new AuthenticationProperties { RedirectUri = redirectUrl },
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            var callbackUrl = Url.Action(nameof(SignedOut), "Account", values: null, protocol: Request.Scheme);
            return SignOut(
                new AuthenticationProperties { RedirectUri = callbackUrl },
                CookieAuthenticationDefaults.AuthenticationScheme,
                OpenIdConnectDefaults.AuthenticationScheme);
        }

        [HttpGet]
        public IActionResult SignedOut()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Redirect to home page if the user is authenticated.
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }

            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UsersViewModel model)
        {
            if (ModelState.IsValid) {
                var userinfo = new Users
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    SlackName = model.SlackName
                };

                await UserRepository.AddAsync(userinfo);

                return Redirect("../Home/Index");
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public IActionResult Register()
        {
            var UserEmail = User.Identity.Name;
            var record = UserRepository.FindAsync(UserEmail);
            if (UserRepository.Any(record.Id) == true)
            {
                return Redirect("../Home/Index");
            }
            else
            {
                return View();
            }
        }
    }
}
