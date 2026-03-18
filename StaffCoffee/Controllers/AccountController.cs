using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffCoffee.BLL.BLL_INTERFACES;
using StaffCoffee.Models;

namespace StaffCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Nhân viên")]
    public class AccountController : ControllerBase
    {

        private readonly I_BLL_StaffAccount _accountBLL;

        public AccountController(I_BLL_StaffAccount accountBLL)
        {
            _accountBLL = accountBLL;
        }

        private int getUserID()
        {
            return (int)HttpContext.Items["UserID"];
        }

        // ================= GET PROFILE =================
        [HttpGet("get-my-profile")]
        public IActionResult GetProfile()
        {
            var userId = getUserID();
            var data = _accountBLL.GetProfile(userId);
            return Ok(data);
        }

        // ================= CHANGE PASSWORD =================
        [HttpPost("change-password")]
        public IActionResult ChangePassword([FromBody] ChangePasswordModel model)
        {
            var userId = getUserID();

            var result = _accountBLL.ChangePassword(
                userId,
                model.OldPassword,
                model.NewPassword,
                out string mess
            );

            if (!result)
                return BadRequest(new { message = mess });

            return Ok(new { message = mess });
        }

        // ================= UPDATE PROFILE =================
        [HttpPut("update-profile")]
        public IActionResult UpdateProfile([FromBody] UpdateProfile model)
        {
            var userId = getUserID();

            var result = _accountBLL.UpdateProfile(userId, model, out string mess);

            if (!result)
                return BadRequest(new { message = mess });

            return Ok(new { message = mess });
        }
    }
}
