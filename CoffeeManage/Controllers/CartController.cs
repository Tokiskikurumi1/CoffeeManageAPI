using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Khách hàng")]

    public class CartController : ControllerBase
    {
        private readonly I_BLL_Cart _cartBLL;
        public CartController(I_BLL_Cart cartBLL)
        {
            _cartBLL = cartBLL;
        }
        private int getUserID()
        {
            return (int)HttpContext.Items["UserID"];
        }

        [HttpPost("add")]
        public IActionResult AddToCart([FromBody] AddToCartRequest model)
        {
            int userId = getUserID();
            model.UserID = userId;
            var result = _cartBLL.AddToCart(model, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok("Thêm vào giỏ thành công");
        }

        [HttpGet]
        public IActionResult GetCart()
        {
            int userId = getUserID();

            var cart = _cartBLL.GetCart(userId);

            return Ok(cart);
        }
        [HttpPut("update")]
        public IActionResult UpdateQuantity([FromBody] UpdateCartRequest model)
        {
            var result = _cartBLL.UpdateQuantity(model.BillDetailID, model.Quantity);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
        [HttpPost("checkout")]
        public IActionResult Checkout()
        {
            int userId = (int)HttpContext.Items["UserID"];

            var result = _cartBLL.Checkout(userId);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
