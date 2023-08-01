using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SiteMVC.Data;
using SiteMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SiteMVC.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BaseContext _baseContext;

        public UserRepository(BaseContext baseContext)
        {
            this._baseContext = baseContext;
        }

        public UserModel GetByLogin(string login)
        {
            return _baseContext.Users.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UserModel ListById(int id)
        {
            return _baseContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public List<UserModel> GetAll()
        {
            return _baseContext.Users.ToList();

        }

        public UserModel Add(UserModel user)
        {
            user.RegisterDate = DateTime.Now;
            _baseContext.Users.Add(user);
            _baseContext.SaveChanges();
            return user;
        }

        public UserModel Att(UserModel user)
        {
            UserModel userDB = ListById(user.Id);

            if (userDB == null)
                throw new Exception("User not found");

            // Validate model
            if (string.IsNullOrEmpty(user.Name))
            {
                // return error
            }

            // Handle nulls before assigning to DB entity
            userDB.Name = user.Name ?? userDB.Name;
            userDB.Email = user.Email ?? userDB.Email;
            userDB.Login = user.Login ?? userDB.Login;
            userDB.Profile = user.Profile;
            userDB.UpdateDate = DateTime.Now;
            try
            {
                _baseContext.Users.Update(userDB);
                _baseContext.SaveChanges();
            }
            catch (SqlException)
            {
                // handle save error
            }

            return userDB;
        }

        public bool Delete(int id)
        {
            UserModel userDB = ListById(id);

            if (userDB == null) throw new Exception("It seems that an error has occurred in the exclusion");

            _baseContext.Users.Remove(userDB);
            _baseContext.SaveChanges();

            return true;
        }
    }
}
