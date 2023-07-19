using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Type the contact Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Type the contact E-mail")]
        [EmailAddress(ErrorMessage = "This E-mail is not valid!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Type the contact Phone")]
        [Phone(ErrorMessage = "This contact is not valid!")]
        public string Celular { get; set; }

    }
}
