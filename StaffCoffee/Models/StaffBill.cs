namespace StaffCoffee.Models
{
    public class StaffBill
    {
        public int BillID { get; set; }

        public string CustomerName { get; set; }

        public string Phone { get; set; }

        public DateTime BillDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }
    }
}
