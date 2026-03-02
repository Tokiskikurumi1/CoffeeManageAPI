namespace AdminCoffeeManage.Models.Request
{
    public class ProductRequest
    {
        public string CoffeeName { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }
    }
}