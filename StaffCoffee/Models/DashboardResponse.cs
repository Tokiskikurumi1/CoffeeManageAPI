using StaffCoffee.Models.DashBoard;

namespace StaffCoffee.Models
{
    public class DashboardResponse
    {
        public DashboardSummary Summary { get; set; }
        public List<StatusChart> StatusChart { get; set; }
        public List<RevenueChart> RevenueChart { get; set; }
    }
}
