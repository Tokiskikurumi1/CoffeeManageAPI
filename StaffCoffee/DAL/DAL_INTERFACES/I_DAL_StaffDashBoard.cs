using StaffCoffee.Models;

namespace StaffCoffee.DAL.DAL_INTERFACES
{
    public interface I_DAL_StaffDashBoard
    {
        DashboardResponse GetDashboard(int userId, string type, DateTime? fromDate, DateTime? toDate);

    }
}
