using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;
using SiteMVC.Models;
using SiteMVC.Repository;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace SiteMVC.Controllers
{
    [OnlyAdminRestrictPage]
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

        public IActionResult DeleteConfirmation(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _userRepository.Delete(id);

                if (deleted)
                {
                    TempData["SuccessMessage"] = "User successfully deleted!";

                }
                else
                {
                    TempData["ErrorMessage"] = "Oops, we were unable to delete your user!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to update your user, try again, error detail: {error.Message}";
                return RedirectToAction("Index");
                throw;
            }
        }

        public IActionResult Edit(int id)
        {
            UserModel user = _userRepository.ListById(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserModel model)
        {

            // Check for validation errors
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            // Save changes
            _userRepository.Att(model);

            // Redirect back to Edit view after saving
            return RedirectToAction("Edit", new { id = model.Id });

        }

        [HttpPost]
        public IActionResult Change(NoPassUserModel noPassUserModel)
        {
            try
            {
                UserModel user = null;

                if (ModelState.IsValid)
                {
                    user = new UserModel();
                    {
                        user.Id = noPassUserModel.Id;
                        user.Name = noPassUserModel.Name;
                        user.Login = noPassUserModel.Login;
                        user.Email = noPassUserModel.Email;
                        user.Profile = noPassUserModel.Profile;
                    }

                    _userRepository.Att(user);
                    TempData["SuccessMessage"] = "User successfully updated";
                    return RedirectToAction("Index");
                }
                return View(user);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to update your user, try again, error detail: {error.Message}";
                return RedirectToAction("Index");
                throw;
            }
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
