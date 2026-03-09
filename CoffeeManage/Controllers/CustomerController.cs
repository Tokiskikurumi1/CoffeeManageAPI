using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Khách hàng")]
    public class CustomerController : ControllerBase
    {
        private readonly I_BLL_Customer _customerBLL;

        public CustomerController(I_BLL_Customer customerBLL)
        {
            _customerBLL = customerBLL;
        }

        private int GetUserID()
        {
            return (int)HttpContext.Items["UserID"];
        }

        // GET PROFILE
        [HttpGet("get-profile")]
        public IActionResult GetProfile()
        {
            int userId = GetUserID();
            var profile = _customerBLL.GetProfile(userId);

            return Ok(profile);
        }

        // UPDATE PROFILE
        [HttpPut("update-profile")]
        public IActionResult UpdateProfile([FromBody] UpdateProfileRequest model)
        {
            int userId = GetUserID();
            model.UserID = userId;

            var result = _customerBLL.UpdateProfile(model);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        // GET MY ORDERS
        [HttpGet("get-orders")]
        public IActionResult GetMyOrders([FromQuery] string status = "All")
        {
            int userId = GetUserID();

            var orders = _customerBLL.GetMyOrders(userId, status);

            return Ok(orders);
        }

        // CANCEL ORDER
        [HttpPost("cancel-order/{billId}")]
        public IActionResult CancelOrder(int billId)
        {
            int userId = GetUserID();

            var result = _customerBLL.CancelOrder(billId, userId);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        // ================= UPLOAD IMAGE =================
        [HttpPost("customer-upload-image")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Không có file!");

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/users");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(folderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var imageUrl = $"/images/users/{fileName}";

            return Ok(new { imageUrl });
        }
    }
}

