using SiteMVC.Models;
using System.Collections.Generic;

namespace SiteMVC.Repository
{
    public interface IUserRepository
    {
        UserModel ListById(int id);
        List<UserModel> GetAll();
        UserModel Add(UserModel user);
        UserModel Att(UserModel user);

        bool Delete(int id);
    }
}
