using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;
using SiteMVC.Models;
using SiteMVC.Repository;
using System;
using System.Collections.Generic;

namespace SiteMVC.Controllers
{
    [LoggedUserPage]
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            List<ContactModel> contact = _contactRepository.GetAll();
            return View(contact);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult DeleteConfirmation(int id)
        {
            ContactModel contact = _contactRepository.ListById(id);
            return View(contact);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                bool deleted = _contactRepository.Delete(id);

                if (deleted) 
                {
                    TempData["SuccessMessage"] = "Contact successfully deleted!";
                    
                }
                else
                {
                    TempData["ErrorMessage"] = "Oops, we were unable to delete your contact!";
                }

                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to update your contact, try again, error detail: {error.Message}";
                return RedirectToAction("Index");
                throw;
            }
        }

        [HttpPost]
        public IActionResult Change(ContactModel contact)
        {
            try
            {
                _contactRepository.Att(contact);
                TempData["SuccessMessage"] = "Contact successfully updated";
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to update your contact, try again, error detail: {error.Message}";
                return RedirectToAction("Index");
                throw;
            }      
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contactRepository.Add(contact);
                    TempData["SuccessMessage"] = "Contact successfully created";
                    return RedirectToAction("Index");
                }

                return View(contact);
            }
            catch (Exception error)
            {
                TempData["ErrorMessage"] = $"Oops, we were unable to register your contact, try again, error detail: {error.Message}";
                return RedirectToAction("Index");
                throw;
            }
        }
    }
}
