
using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.DAL.DAL_INTERFACES;
using CoffeeManage.Models;
using CoffeeManage.Models.Request;
using CoffeeManage.Models.Respone;

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
        public List<CartItemResponse> GetCart(int userId)
        {
            return _cartDAL.GetCart(userId);
        }
        public (bool Success, string Message) UpdateQuantity(int billDetailId, int quantity)
        {
            return _cartDAL.UpdateQuantity(billDetailId, quantity);
        }
        public (bool Success, string Message) Checkout(int userId)
        {
            return _cartDAL.Checkout(userId);
        }
        
    }
}
