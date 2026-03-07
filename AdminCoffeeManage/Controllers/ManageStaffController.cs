using AdminCoffeeManage.BLL.BLL_INTERFACES;
using AdminCoffeeManage.Models.StaffManage;
using Microsoft.AspNetCore.Mvc;

namespace AdminCoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageStaffController : ControllerBase
    {
        private readonly I_BLL_ManageStaff _staffBLL;

        public ManageStaffController(I_BLL_ManageStaff staffBLL)
        {
            _staffBLL = staffBLL;
        }

        [HttpGet("load-staff")]
        public IActionResult LoadAll()
        {
            var data = _staffBLL.GetAllStaff();

            if (data.Count == 0)
                return NotFound("Không có nhân viên!");

            return Ok(data);
        }

        [HttpGet("detail/{id}")]
        public IActionResult Detail(int id)
        {
            var data = _staffBLL.GetStaffDetail(id);

            if (data == null)
                return NotFound("Không tìm thấy nhân viên!");

            return Ok(data);
        }

        [HttpPost("add-staff")]
        public IActionResult Add([FromBody] StaffRequest req)
        {
            var result = _staffBLL.AddStaff(req, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok("Thêm nhân viên thành công!");
        }

        [HttpPut("update-staff/{id}")]
        public IActionResult Update(int id, [FromBody] StaffRequest req)
        {
            var result = _staffBLL.UpdateStaff(id, req, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok("Cập nhật thành công!");
        }

        [HttpPut("update-status/{id}")]
        public IActionResult UpdateStatus(int id, int status)
        {
            var result = _staffBLL.UpdateStatus(id, status, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok(mess);
        }

        [HttpDelete("delete-staff/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _staffBLL.DeleteStaff(id, out string mess);

            if (!result)
                return BadRequest(mess);

            return Ok("Xóa nhân viên thành công!");
        }
    }
}
