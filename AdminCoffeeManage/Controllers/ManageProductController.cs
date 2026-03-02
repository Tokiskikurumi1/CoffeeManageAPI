using Microsoft.AspNetCore.Mvc;

namespace AdminCoffeeManage.Controllers
{
    public class ManageProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
