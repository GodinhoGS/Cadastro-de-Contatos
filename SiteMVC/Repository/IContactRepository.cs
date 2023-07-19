using SiteMVC.Models;
using System.Collections.Generic;

namespace SiteMVC.Repository
{
    public interface IContactRepository
    {
        ContactModel ListById(int id);
        List<ContactModel> GetAll();
        ContactModel Add(ContactModel contact);
        ContactModel Att(ContactModel contact);

        bool Delete(int id);
    }
}
