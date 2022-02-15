using Microsoft.AspNetCore.Mvc;

namespace ecommerce.webuı.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
