namespace AdminCoffeeManage.Models.Report
{
    public class TopCustomer
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public int TotalBills { get; set; }
        public decimal TotalSpent { get; set; }
    }
}
