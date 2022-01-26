using AweForum.Data;
using AweForum.Data.Static;
using AweForum.Data.ViewModels;
using AweForum.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private AppDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {           
            if(User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM newLogin)
        {
            if (!ModelState.IsValid)
            {
                return View(newLogin);
            }

            AppUser user;

            if (Util.IsValidEmail(newLogin.EmailOrUsername))
            {
                user = await _userManager.FindByEmailAsync(newLogin.EmailOrUsername);
            }
            else
            {
                user = await _userManager.FindByNameAsync(newLogin.EmailOrUsername);
            }

            if (user != null)
            {
                var isValidPasword = await _userManager.CheckPasswordAsync(user, newLogin.Password);
                if (isValidPasword)
                {
                    var loginResult = await _signInManager.PasswordSignInAsync(user, newLogin.Password, false, false);

                    if (loginResult.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            TempData["Error"] = "Wrong credentials. Please try again!";
            return View(newLogin);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
