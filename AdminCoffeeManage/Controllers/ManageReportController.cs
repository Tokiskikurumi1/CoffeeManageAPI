using AdminCoffeeManage.BLL.BLL_INTERFACES;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdminCoffeeManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageReportController : ControllerBase
    {
        private readonly I_BLL_Report _bll;

        public ManageReportController(I_BLL_Report bll)
        {
            _bll = bll;
        }

        // ===============================================================
        // ======================== GET SUMARY ===========================
        // ===============================================================

        [HttpGet("get-all-summary")]
        public IActionResult GetSummary()
        {
            var result = _bll.GetDashboardSummary();

            return Ok(result);
        }

        [HttpGet("get-summary-by-date")]
        public IActionResult GetSummaryByDate(DateTime from, DateTime to)
        {
            var result = _bll.GetDashboardSummaryByDate(from, to);
            if(result.Count == 0)
            {
                return BadRequest("Không có dữ liệu");
            }
            return Ok(result);
        }
        [HttpGet("get-summary-by-type")]
        public IActionResult GetSummaryByType(string type)
        {
            var result = _bll.GetDashboardSummaryByType(type);
            if (result.Count == 0)
            {
                return BadRequest("Không có dữ liệu");
            }
            return Ok(result);
        }
        // ===============================================================
        // =================== GET TOP PRODUCT ===========================
        // ===============================================================
        [HttpGet("get-top-produc-all")]
        public IActionResult GetAllProduct()
        {
            var data = _bll.GetAllProduct();
            return Ok(data);
        }

        [HttpGet("get-top-product-by-date")]
        public IActionResult GetTopProductDate(DateTime from, DateTime to)
        {
            var data = _bll.GetTopProductsByDate(from, to);
            return Ok(data);
        }

        [HttpGet("get-top-products-by-type")]
        public IActionResult GetTopProductsType(string type)
        {
            var data = _bll.GetTopProductsByType(type);
            return Ok(data);
        }
        // ===============================================================
        // =================== GET TOP CATEGORY ==========================
        // ===============================================================
        [HttpGet("get-top-category-all")]
        public IActionResult GetAllCate()
        {
            var data = _bll.GetAllCategory();
            return Ok(data);
        }

        [HttpGet("get-top-category-by-date")]
        public IActionResult GetTopCateDate(DateTime from, DateTime to)
        {
            var data = _bll.GetCategoryByDate(from, to);
            return Ok(data);
        }

        [HttpGet("get-top-category-by-type")]
        public IActionResult GetTopCateType(string type)
        {
            var data = _bll.GetCategoryByType(type);
            return Ok(data);
        }


        // ===============================================================
        // =================== GET TOP CUSTOMER ==========================
        // ===============================================================
        [HttpGet("get-top-customer-all")]
        public IActionResult GetAllCustomer()
        {
            var data = _bll.GetAllCustomer();
            return Ok(data);
        }

        [HttpGet("get-top-customer-by-date")]
        public IActionResult GetTopCustomerDate(DateTime from, DateTime to)
        {
            var data = _bll.GetTopCustomersByDate(from, to);
            return Ok(data);
        }

        [HttpGet("get-top-customer-by-type")]
        public IActionResult GetTopCustomerType(string type)
        {
            var data = _bll.GetTopCustomerByType(type);
            return Ok(data);
        }
    }
}
