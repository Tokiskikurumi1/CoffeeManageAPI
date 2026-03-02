namespace AdminCoffeeManage.Models
{
    public class ProductDetail
    {
        public int CoffeeID { get; set; }
        public string CoffeeName { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int Status { get; set; }

    }
}
