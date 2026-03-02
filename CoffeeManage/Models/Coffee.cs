namespace CoffeeManage.Models
{
    public class Coffee
    {
        public int CoffeeID { get; set; }
        public string CoffeeName { get; set; }
        public decimal Price { get; set; }
        public string ImageURL { get; set; }
        public int CategoryID { get; set; }
    }
}