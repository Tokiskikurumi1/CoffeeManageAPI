using CoffeeManage.Models.Request;
using CoffeeManage.Models.Respone;

namespace CoffeeManage.DAL.DAL_INTERFACES
{
    public interface I_DAL_Cart
    {
        bool AddToCart(AddToCartRequest req, out string mess);
        (bool Success, string Message) Checkout(int userId);
        List<CartItemResponse> GetCart(int userId);
        (bool Success, string Message) UpdateQuantity(int billDetailId, int quantity);
    }
}
