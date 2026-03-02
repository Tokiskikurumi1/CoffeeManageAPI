using Microsoft.AspNetCore.Mvc;
using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.Models;

namespace CoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoadCoffeeController : ControllerBase
    {
        private readonly I_BLL_LoadCoffee _coffeeBLL;

        public LoadCoffeeController(I_BLL_LoadCoffee coffeeBLL)
        {
            _coffeeBLL = coffeeBLL;
        }

        // ================= LOAD CATEGORY =================
        [HttpGet("load-category")]
        public IActionResult LoadCategory()
        {
            var cate = _coffeeBLL.GetAllCategory();

            if (cate.Count == 0)
                return NotFound("Không có danh mục!");

            return Ok(cate);
        }

        // ================= LOAD ALL PRODUCT =================
        [HttpGet("load-product")]
        public IActionResult LoadAllProduct()
        {
            var products = _coffeeBLL.GetAllCoffee();

            if (products.Count == 0)
                return NotFound("Không có sản phẩm!");

            return Ok(products);
        }

        // ================= LOAD PRODUCT BY CATEGORY =================
        [HttpGet("load-product-by-category/{categoryID}")]
        public IActionResult LoadByCategory(int categoryID)
        {
            var products = _coffeeBLL.GetCoffeeByCategory(categoryID);

            if (products.Count == 0)
                return NotFound("Không có sản phẩm thuộc danh mục này!");

            return Ok(products);
        }

        [HttpGet("load-product-by-ID/{coffeeID}")]
        public IActionResult LoadByCoffeeID(int coffeeID)
        {
            var products = _coffeeBLL.GetCoffeeByID(coffeeID);

            if (products.Count == 0)
                return NotFound("Không có sản phẩm thuộc danh mục này!");

            return Ok(products);
        }
    }
}