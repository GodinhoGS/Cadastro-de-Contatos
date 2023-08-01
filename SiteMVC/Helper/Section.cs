using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SiteMVC.Models;
using System.Net.Http;
using static System.Collections.Specialized.BitVector32;

namespace SiteMVC.Helper
{
    public class Section : ISection
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly Section _section;

        public Section(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        public void CreateUserSection(UserModel user)
        {
            string value = JsonConvert.SerializeObject(user);
            _httpContext.HttpContext.Session.SetString("sectionUserLogged", value);
        }

        public UserModel GetUserSection()
        {
            string sectionUser = _httpContext.HttpContext.Session.GetString("sectionUserLogged");

            if (string.IsNullOrEmpty(sectionUser)) return null;

            return JsonConvert.DeserializeObject<UserModel>(sectionUser);
        }

        public void RemoveUserSection()
        {
            _httpContext.HttpContext.Session.Remove("sectionUserLogged");
        }
    }
}
