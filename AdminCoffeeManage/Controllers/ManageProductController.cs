using AdminCoffeeManage.BLL.BLL_INTERFACES;
using AdminCoffeeManage.Models.Request;
using AdminCoffeeManage.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminCoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageProductController : ControllerBase
    {
        private readonly I_BLL_ManageProduct _coffeeBLL;

        public ManageProductController(I_BLL_ManageProduct coffeeBLL)
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
        // ================= LOAD PRODUCT BY ID =================
        //[HttpGet("load-product-by-ID/{coffeeID}")]
        //public IActionResult LoadByCoffeeID(int coffeeID)
        //{
        //    var products = _coffeeBLL.GetCoffeeByID(coffeeID);

        //    if (products.Count == 0)
        //        return NotFound("Không có sản phẩm thuộc danh mục này!");

        //    return Ok(products);
        //}
        [HttpPost("add-product")]
        public IActionResult Add([FromBody] ProductRequest req)
        {
            var result = _coffeeBLL.AddProduct(req, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok("Thêm sản phẩm thành công!");
        }

        [HttpPut("update-product/{id}")]
        public IActionResult Update(int id, [FromBody] ProductRequest req)
        {
            var result = _coffeeBLL.UpdateProduct(id, req, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok("Cập nhật thành công!");
        }

        [HttpDelete("delete-product/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _coffeeBLL.DeleteProduct(id, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok("Xóa thành công!");
        }

        // ================= UPDATE STATUS (LOCK / UNLOCK) =================
        [HttpPut("update-status/{id}")]
        public IActionResult UpdateStatus(int id)
        {
            var result = _coffeeBLL.UpdateStatus(id, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok(mess);
        }

        // ================= UPLOAD IMAGE =================
        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Không có file!");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/products");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = $"/images/products/{fileName}";

            return Ok(new { imageUrl });
        }
    }
}
