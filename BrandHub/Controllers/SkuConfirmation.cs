using Brandhub.Business.Interface;
using Brandhub.Business.Services;
using BrandHub.Map.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace BrandHub.Controllers
{
    public class SkuConfirmation : Controller
    {
        public string reference;
        IHttpContextAccessor context;
        private readonly IPalletServices PalletService;
        public SkuConfirmation(IHttpContextAccessor _context, IPalletServices _PalletService)
        {
                context= _context;
            PalletService= _PalletService;
        }
        public IActionResult Index(string refNo,string totalPallet)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            objComplex.PalletNo = totalPallet;
            objComplex.counter = 1;
            ViewBag.counter = objComplex.counter;
            ViewBag.Pallet = objComplex.PalletNo;
            context.HttpContext.Session.SetObject("LoginSession", objComplex);
            this.reference = refNo;
            ViewBag.refer = this.reference;
            return View();
          
        }
        public IActionResult Pallet2SerialNumberConfirmation(string refNo,int counter ,string PalletNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            //objComplex.PalletNo = PalletNo;
          //  objComplex.counter= counter;
            ViewBag.counter = counter;
            ViewBag.Pallet = objComplex.PalletNo;
           // context.HttpContext.Session.SetObject("LoginSession", objComplex);

            this.reference = refNo;
            ViewBag.refer = this.reference;
            return View();

        }


        public IActionResult Pallet1SerialNumberConfirmation(string refNo)
        {

            this.reference = refNo;
            ViewBag.refer = this.reference;
            return View();

        }


        [HttpPost]
        public async Task<JsonResult> SetAnswer(string answer, string question, string refNo,string totalPallet)
        {
            
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            objComplex.PalletNo = totalPallet;
            objComplex.counter = 1;
            string userName = objComplex.Username;
          var resp=  await PalletService.SetAnswerAsync(refNo, question, userName, answer);
            return Json(resp);

        }

    }
}
