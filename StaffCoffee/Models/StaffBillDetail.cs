namespace StaffCoffee.Models
{
    public class StaffBillDetail
    {
        public string CoffeeName { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }
    }
}
