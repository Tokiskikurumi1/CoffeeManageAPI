using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaffCoffee.BLL.BLL_INTERFACES;

namespace StaffCoffee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Nhân viên")]
    public class DashBoardController : ControllerBase
    {
        private readonly I_BLL_StaffDashBoard _dashboardBLL;

        public DashBoardController(I_BLL_StaffDashBoard dashboardBLL)
        {
            _dashboardBLL = dashboardBLL;
        }

        private int getUserID()
        {
            return (int)HttpContext.Items["UserID"];
        }

        [HttpGet("dashboard")]
        public IActionResult GetDashboard(
            string type = "ALL",
            DateTime? fromDate = null,
            DateTime? toDate = null)
        {
            var userId = getUserID();
            var data = _dashboardBLL.GetDashboard(userId, type, fromDate, toDate);
            return Ok(data);
        }
            
    }
}
