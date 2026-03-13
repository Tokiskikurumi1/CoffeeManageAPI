using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffCoffee.BLL.BLL_INTERFACES;
using System.Security.Claims;

namespace StaffCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Nhân viên")]
    public class ManageBillController : ControllerBase
    {
        private readonly I_BLL_StaffBill _billBLL;

        public ManageBillController(I_BLL_StaffBill billBLL)
        {
            _billBLL = billBLL;
        }

        private int getUserID()
        {
            return (int)HttpContext.Items["UserID"];
        }

        // ================= GET ALL BILL =================
        [HttpGet("get-all-bill")]
        public IActionResult GetAllBill()
        {
            var data = _billBLL.GetAllBill();
            return Ok(data);
        }

        // ================= GET BILL DETAIL =================
        [HttpGet("get-bill-detail/{id}")]
        public IActionResult GetBillDetail(int id)
        {
            var data = _billBLL.GetBillDetail(id);

            if (data == null || data.Count == 0)
                return NotFound("Không tìm thấy hóa đơn");

            return Ok(data);
        }

        // ================= UPDATE BILL STATUS =================
        [HttpPut("update-status")]
        public IActionResult UpdateStatus(int billId, int status)
        {
            var staffId = getUserID();

            var result = _billBLL.UpdateBillStatus(billId, staffId, status, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok("Cập nhật trạng thái thành công!");
        }
    }
}
