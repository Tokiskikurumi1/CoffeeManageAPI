namespace StaffCoffee.Models
{
    public class StaffBillDetail
    {
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public int Status { get; set; }
        public string StatusName { get; set; }

        public string CoffeeName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
