using StaffCoffee.Models;
namespace StaffCoffee.BLL.BLL_INTERFACES
{
    public interface I_BLL_StaffAccount
    {
        StaffProfile GetProfile(int userId);
        bool ChangePassword(int userId, string oldPass, string newPass, out string mess);
        bool UpdateProfile(int userId, UpdateProfile model, out string mess);
    }
}
