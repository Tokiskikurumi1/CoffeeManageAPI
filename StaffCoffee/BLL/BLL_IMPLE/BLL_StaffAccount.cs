using StaffCoffee.BLL.BLL_INTERFACES;
using StaffCoffee.DAL.DAL_INTERFACES;
using StaffCoffee.Models;

namespace StaffCoffee.BLL.BLL_IMPLE
{
    public class BLL_StaffAccount : I_BLL_StaffAccount
    {
        private readonly I_DAL_StaffAccount _accountDAL;

        public BLL_StaffAccount(I_DAL_StaffAccount accountDAL)
        {
            _accountDAL = accountDAL;
        }

        public StaffProfile GetProfile(int userId)
        {
            return _accountDAL.GetProfile(userId);
        }

        public bool ChangePassword(int userId, string oldPass, string newPass, out string mess)
        {
            return _accountDAL.ChangePassword(userId, oldPass, newPass, out mess);
        }

        public bool UpdateProfile(int userId, UpdateProfile model, out string mess)
        {
            return _accountDAL.UpdateProfile(userId, model, out mess);
        }
    }
}
