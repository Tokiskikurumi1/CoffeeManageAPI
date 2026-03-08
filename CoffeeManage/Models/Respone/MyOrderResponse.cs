namespace CoffeeManage.Models.Respone
{
    public class MyOrderResponse
    {
        public int BillID { get; set; }

        public DateTime BillDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int Status { get; set; }

        public string StatusName { get; set; }

        public string CoffeeName { get; set; }

        public string ImageURL { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal SubTotal { get; set; }
    }
}
