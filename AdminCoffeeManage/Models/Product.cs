namespace AdminCoffeeManage.Models
{
    public class Product
    {
        public int CoffeeID { get; set; }
        public string CoffeeName { get; set; }
        public decimal Price { get; set; }
        public string? ImageURL { get; set; }
        public int CategoryID { get; set; }
    }
}
