using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repository;
using System.Collections.Generic;

namespace SiteMVC.Controllers
{
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
            _contactRepository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Change(ContactModel contact)
        {
                _contactRepository.Att(contact);
                return RedirectToAction("Index");      
        }

        [HttpPost]
        public IActionResult Create(ContactModel contact)
        {
            if(ModelState.IsValid)
            {
                _contactRepository.Add(contact);
                return RedirectToAction("Index");
            }

            return View(contact);
        }
    }
}
