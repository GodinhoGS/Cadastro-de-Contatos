using System.ComponentModel.DataAnnotations;

namespace SiteMVC.Models
{
    public class ContactModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }
 
        public string Celular { get; set; }

    }
}
