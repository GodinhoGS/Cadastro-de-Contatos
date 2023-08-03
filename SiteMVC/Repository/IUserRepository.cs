using SiteMVC.Models;
using System.Collections.Generic;

namespace SiteMVC.Repository
{
    public interface IUserRepository
    {
        UserModel GetByMailnLogin(string email, string login);
        UserModel GetByLogin(string login);
        List<UserModel> GetAll();
        UserModel ListById(int id);
        UserModel Add(UserModel user);
        UserModel Att(UserModel user);

        bool Delete(int id);
    }
}
