using Microsoft.AspNetCore.Mvc;
using SiteMVC.Filters;

namespace SiteMVC.Controllers
{
    [LoggedUserPage]
    public class RestrictController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
