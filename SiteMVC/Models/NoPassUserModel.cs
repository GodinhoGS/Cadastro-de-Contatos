using SiteMVC.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class NoPassUserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Type the user Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Type the user Login!")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Type the user E-mail")]
        [EmailAddress(ErrorMessage = "This E-mail is not valid!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Select the profile type!")]
        public ProfileEnum? Profile { get; set; }
    }
}
