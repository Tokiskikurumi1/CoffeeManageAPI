namespace StaffCoffee.Models.DashBoard
{
    public class DashboardSummary
    {
        public int TotalOrders { get; set; }
        public int Pending { get; set; }
        public int Shipping { get; set; }
        public int Completed { get; set; }
        public int Cancelled { get; set; }
    }
}
