using CoffeeManage.Models.Request;
using CoffeeManage.Models.Respone;

namespace CoffeeManage.BLL.BLL_INTERFACES
{
    public interface I_BLL_Cart
    {
        bool AddToCart(AddToCartRequest add, out string mess);
        (bool Success, string Message) Checkout(int userId);
        List<CartItemResponse> GetCart(int userId);
        (bool Success, string Message) UpdateQuantity(int billDetailId, int quantity);

    }
}
