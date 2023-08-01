using SiteMVC.Models;

namespace SiteMVC.Helper
{
    public interface ISection
    {
        void CreateUserSection(UserModel user);
        void RemoveUserSection();
        UserModel GetUserSection();
    }
}
