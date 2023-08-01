using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Type the Login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Type the Password!")]
        public string Password { get; set; }
    }
}
