using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteMVC.Helper;
using SiteMVC.Models;
using SiteMVC.Repository;
using System;

namespace SiteMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISection _section;

        public LoginController(IUserRepository userRepository,
                               ISection section)
        {
            _userRepository = userRepository;
            _section = section;
        }

        public IActionResult Index()
        {
            // if the user were logged, redirect to home

            if (_section.GetUserSection() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Leave()
        {
            _section.RemoveUserSection();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Enter(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.GetByLogin(loginModel.Login);

                    if(user != null)
                    {
                        if (user.ValidPassword(loginModel.Password))
                        {
                            _section.CreateUserSection(user);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["ErrorMessage"] = $"Password isn't valid. Please, try again";
                    }

                    TempData["ErrorMessage"] = $"User/Password isn't valid. Please, try again";
                }

                return View("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to make your login, try again, error detail: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    
    }
}
