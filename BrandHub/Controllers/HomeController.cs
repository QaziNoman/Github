using Brandhub.Business.Interface;
using Brandhub.Business.Services;
using BrandHub.Map.Models;
using BrandHub.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BrandHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor context;
        private readonly IGetOrderServices orderServices;
        public HomeController(ILogger<HomeController> logger,IGetOrderServices _orderServices, IHttpContextAccessor _context)
        {
            _logger = logger;
            orderServices = _orderServices;
            this.context = _context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult PlatteWrapped(string refNo)
        {

            ViewBag.RefNo = refNo;
            return View();
        }
        public IActionResult PlatteCustomerLabel(string refNo)
        {

            ViewBag.RefNo = refNo;
            return View();
        }
        public async  Task<IActionResult> CustomerName(string refNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            var Singleorder = await orderServices.GetOrderByReferenceAsync(refNo, objComplex.Username);
            ViewBag.customerName = Singleorder.customerName;
            ViewBag.RefNo = refNo;
            return View();
        }




        public IActionResult LabelStuck(string refNo)
        {

            ViewBag.RefNo = refNo;
            return View();
        }


        public IActionResult AssistmentComplete(string refNo)
        {

            ViewBag.RefNo = refNo;
            return View();
        }



        public IActionResult PrintOutQR(string refNo)
        {
            ViewBag.RefNo = refNo;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}