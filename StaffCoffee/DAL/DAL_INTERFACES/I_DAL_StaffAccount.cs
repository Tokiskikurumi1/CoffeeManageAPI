using StaffCoffee.Models;

namespace StaffCoffee.DAL.DAL_INTERFACES
{
    public interface I_DAL_StaffAccount
    {
        StaffProfile GetProfile(int userId);
        bool ChangePassword(int userId, string oldPass, string newPass, out string mess);
        bool UpdateProfile(int userId, UpdateProfile model, out string mess);
    }
}
