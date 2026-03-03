namespace CoffeeManage.Models.Respone
{
    public class CartItemResponse
    {
        public int BillDetailID { get; set; }
        public int CoffeeID { get; set; }
        public string CoffeeName { get; set; }
        public string ImageURL { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
