using CoffeeManage.BLL.BLL_INTERFACES;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotalProductController : ControllerBase
    {
        private readonly I_BLL_TopProduct _coffeeBLL;
        public TotalProductController(I_BLL_TopProduct coffeeBLL)
        {
            _coffeeBLL = coffeeBLL;
        }
        [HttpGet("top-selling")]
        public IActionResult GetTopSelling()
        {
            var data = _coffeeBLL.GetTopSellingCoffee();

            if (data.Count == 0)
                return NotFound("Không có dữ liệu!");

            return Ok(data);
        }
    }
}
