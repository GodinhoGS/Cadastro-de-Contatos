using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class ResetPasswordModel
    {
        [Required(ErrorMessage = "Type the Login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Type the Email!")]
        public string Email { get; set; }
    }
}
