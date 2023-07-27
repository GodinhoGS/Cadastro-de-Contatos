using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repository;
using System;
using System.Collections.Generic;

namespace SiteMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            List<UserModel> user = _userRepository.GetAll();
            return View(user);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _userRepository.Add(user);
                    TempData["SuccessMessage"] = "User successfully created";
                    return RedirectToAction("Index");
                }

                return View(user);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to register your user, try again, error detail: {error.Message}";
                return RedirectToAction("Index");
                throw;
            }
        }
    }
}
