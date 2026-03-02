using CoffeeManage.Models.Request;

namespace CoffeeManage.DAL.DAL_INTERFACES
{
    public interface I_DAL_Cart
    {
        bool AddToCart(AddToCartRequest req, out string mess);
        (bool Success, string Message) Checkout(int userId);
    }
}
