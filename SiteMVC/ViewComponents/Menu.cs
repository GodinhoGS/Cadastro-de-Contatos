using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using SiteMVC.Models;


namespace SiteMVC.ViewComponents
{
    public class Menu : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            string sectionUser = HttpContext.Session.GetString("sectionUserLogged");

            if (string.IsNullOrEmpty(sectionUser)) return null;

            UserModel user = JsonConvert.DeserializeObject<UserModel>(sectionUser);

            return View(user);
        }
    }
}
