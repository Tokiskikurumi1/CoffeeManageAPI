using System.Text.Json.Serialization;

namespace CoffeeManage.Models.Request
{
    public class AddToCartRequest
    {
        [JsonIgnore]
        public int UserID { get; set; }
        public int CoffeeID { get; set; }
        public int Quantity { get; set; }
    }
}
