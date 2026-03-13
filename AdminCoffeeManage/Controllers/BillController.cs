using AdminCoffeeManage.BLL.BLL_INTERFACES;
using Microsoft.AspNetCore.Mvc;

namespace AdminCoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly I_BLL_Bill _billBLL;

        public BillController(I_BLL_Bill billBLL)
        {
            _billBLL = billBLL;
        }

        // GET: api/bill
        [HttpGet("get-all-bill")]
        public IActionResult GetAllBill()
        {
            var data = _billBLL.GetAllBill();
            return Ok(data);
        }

        [HttpGet("get-bill-by-id/{id}")]
        public IActionResult GetBillDetail(int id)
        {
            var data = _billBLL.GetBillDetail(id);

            if (data == null || data.Products.Count == 0)
                return NotFound("Không tìm thấy hóa đơn");

            return Ok(data);
        }

    }
}
