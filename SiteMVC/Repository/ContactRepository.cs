using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SiteMVC.Data;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMVC.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly BaseContext _baseContext;
        public ContactRepository(BaseContext baseContext)
        {
            this._baseContext = baseContext;
        }

        public ContactModel ListById(int id)
        {
            return _baseContext.Contact.FirstOrDefault(x => x.Id == id);
        }

        public List<ContactModel> GetAll()
        {
            return _baseContext.Contact.ToList();

        }

        public ContactModel Add(ContactModel contact)
        {
            _baseContext.Contact.Add(contact);
            _baseContext.SaveChanges();
            return contact;
        }

        public ContactModel Att(ContactModel contact)
        {
            ContactModel contactDB = ListById(contact.Id);

            if (contactDB == null)
                throw new Exception("Contact not found");

            // Validate model
            if (string.IsNullOrEmpty(contact.Name))
            {
                // return error
            }

            // Handle nulls before assigning to DB entity
            contactDB.Name = contact.Name ?? contactDB.Name;
            contactDB.Email = contact.Email ?? contactDB.Email;
            contactDB.Celular = contact.Celular ?? contactDB.Celular;

            try
            {
                _baseContext.Contact.Update(contactDB);
                _baseContext.SaveChanges();
            }
            catch (SqlException ex)
            {
                // handle save error
            }

            return contactDB;
        }

        public bool Delete(int id)
        {
            ContactModel contactDB = ListById(id);

            if (contactDB == null) throw new Exception("It seems that an error has occurred in the exclusion");

            _baseContext.Contact.Remove(contactDB);
            _baseContext.SaveChanges();

            return true;
        }

    }
}
