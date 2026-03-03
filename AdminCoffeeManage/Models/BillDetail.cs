namespace AdminCoffeeManage.Models
{
    public class BillDetail
    {
        public int BillID { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime BillDate { get; set; }
        public string CoffeeName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
