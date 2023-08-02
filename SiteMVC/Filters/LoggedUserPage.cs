using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using SiteMVC.Models;

namespace SiteMVC.Filters
{
    public class LoggedUserPage : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string sectionUser = context.HttpContext.Session.GetString("sectionUserLogged"); 

            if (string.IsNullOrEmpty(sectionUser))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" },  { "action", "Index" } });
            }
            else {
                UserModel user = JsonConvert.DeserializeObject<UserModel>(sectionUser);
                if (user == null)
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "Login" }, { "action", "Index" } });
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
