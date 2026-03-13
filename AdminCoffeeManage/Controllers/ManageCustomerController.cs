using AdminCoffeeManage.BLL.BLL_INTERFACES;
using Microsoft.AspNetCore.Mvc;

namespace AdminCoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageCustomerController : ControllerBase
    {
        private readonly I_BLL_ManageCustomer _bll;

        public ManageCustomerController(I_BLL_ManageCustomer bll)
        {
            _bll = bll;
        }

        // ================= GET BILL DETAIL =================
        //[HttpGet("get-bill-detail/{billID}")]
        //public IActionResult GetBillDetail(int billID)
        //{
        //    var data = _bll.GetBillDetail(billID);

        //    if (data == null || data.Count == 0)
        //        return NotFound("Không tìm thấy hóa đơn!");

        //    return Ok(data);
        //}

        // ================= GET ALL CUSTOMER =================
        [HttpGet("get-all-customer")]
        public IActionResult GetAllCustomer()
        {
            var data = _bll.GetAllCustomer();

            if (data.Count == 0)
                return NotFound("Không có khách hàng!");

            return Ok(data);
        }
        // ================= GET CUSTOMER DETAIL =================
        [HttpGet("get-customer-detail/{userID}")]
        public IActionResult GetCustomerDetail(int userID)
        {
            Console.WriteLine("UserID nhận được: " + userID);

            var data = _bll.GetCustomerDetail(userID);

            if (data == null || data.Count == 0)
                return NotFound("Không có khách hàng!");

            return Ok(data);
        }
        // ================= UPDATE STATUS =================
        [HttpPut("update-status/{userID}/{status}")]
        public IActionResult UpdateStatus(int userID, int status)
        {
            var result = _bll.UpdateUserStatus(userID, status, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok(mess);
        }
    }
}
