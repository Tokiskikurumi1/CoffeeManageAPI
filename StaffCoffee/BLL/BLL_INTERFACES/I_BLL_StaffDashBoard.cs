using StaffCoffee.Models;

namespace StaffCoffee.BLL.BLL_INTERFACES
{
    public interface I_BLL_StaffDashBoard
    {
        DashboardResponse GetDashboard(int userId, string type, DateTime? fromDate, DateTime? toDate);

    }
}
