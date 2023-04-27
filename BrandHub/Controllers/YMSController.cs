using Microsoft.AspNetCore.Mvc;

namespace BrandHub.Controllers
{
    public class YMSController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult YMSList()
        {
            return View();
        }
    }
}
