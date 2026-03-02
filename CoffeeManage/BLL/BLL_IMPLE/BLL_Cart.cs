
using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.DAL.DAL_INTERFACES;
using CoffeeManage.Models;
using CoffeeManage.Models.Request;

namespace CoffeeManage.BLL.BLL_IMPLE
{
    public class BLL_Cart : I_BLL_Cart
    {
        private readonly I_DAL_Cart _cartDAL;
        public BLL_Cart(I_DAL_Cart cart)
        {
            _cartDAL = cart;
        }
        public bool AddToCart(AddToCartRequest add, out string mess)
        {
            return _cartDAL.AddToCart(add, out mess);
        }

        public (bool Success, string Message) Checkout(int userId)
        {
            return _cartDAL.Checkout(userId);
        }
    }
}
