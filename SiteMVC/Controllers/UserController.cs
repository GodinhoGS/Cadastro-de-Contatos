using Microsoft.AspNetCore.Mvc;
using SiteMVC.Models;
using SiteMVC.Repository;
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
    }
}
