using SiteMVC.Enums;
using SiteMVC.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class UserModel
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
        [Required(ErrorMessage = "Type the user Password!")]
        public string Password { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        public bool ValidPassword(string password)
        {
            return Password == password.HashGenerator();
        } 

        public void SetHashPassword()
        {
            Password = Password.HashGenerator();
        }

        public string NewPassGenerator()
        {
            string newPassword = Guid.NewGuid().ToString().Substring(0, 8);
            Password = newPassword.HashGenerator();
            return newPassword;
        }
    }
}
