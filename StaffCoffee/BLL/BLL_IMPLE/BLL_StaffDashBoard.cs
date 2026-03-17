using StaffCoffee.BLL.BLL_INTERFACES;
using StaffCoffee.DAL.DAL_INTERFACES;
using StaffCoffee.Models;

namespace StaffCoffee.BLL.BLL_IMPLE
{
    public class BLL_StaffDashBoard : I_BLL_StaffDashBoard
    {
        private readonly I_DAL_StaffDashBoard _dashboardDAL;

        public BLL_StaffDashBoard(I_DAL_StaffDashBoard dashboardDAL)
        {
            _dashboardDAL = dashboardDAL;
        }

        public DashboardResponse GetDashboard(int userId, string type, DateTime? fromDate, DateTime? toDate)
        {
            return _dashboardDAL.GetDashboard(userId, type, fromDate, toDate);
        }
    }
}
