using CoffeeManage.Models.Request;

namespace CoffeeManage.BLL.BLL_INTERFACES
{
    public interface I_BLL_Cart
    {
        bool AddToCart(AddToCartRequest add, out string mess);
        (bool Success, string Message) Checkout(int userId);

    }
}
