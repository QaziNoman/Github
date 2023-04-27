using Brandhub.Business.Interface;
using Brandhub.Business.Services;
using BrandHub.Map.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace BrandHub.Controllers
{
    public class SavingImages : Controller
    {

        public string reference;
        private readonly IHttpContextAccessor context;
        private readonly IPalletServices PalletService;
        public SavingImages(IHttpContextAccessor context, IPalletServices _PalletService)
        {
            PalletService= _PalletService;
            this.context = context;
        }

        public IActionResult LeftImage(String refNo, int counter, string PalletNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            ViewBag.counter = counter;
            ViewBag.Pallet = objComplex.PalletNo;
            ViewBag.refer = refNo;
            return View();
        }

        public IActionResult RightImage(String refNo, int counter, string PalletNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            ViewBag.counter = counter;
            ViewBag.Pallet = objComplex.PalletNo;
            ViewBag.refer = refNo;
            return View();
        }

        public IActionResult FrontImage(String refNo, int counter, string PalletNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            ViewBag.counter = counter;
            ViewBag.Pallet = objComplex.PalletNo;

            ViewBag.refer = refNo;

            return View();
        }

        public IActionResult BackImage(String refNo, int counter, string PalletNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            ViewBag.counter = counter;
            ViewBag.Pallet = objComplex.PalletNo;

            ViewBag.refer = refNo;
            return View();
        }

        public IActionResult TopImage(String refNo, int counter, string PalletNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            ViewBag.counter = counter;
            ViewBag.Pallet = objComplex.PalletNo;
         
            ViewBag.refer = refNo;

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SaveImage(string dat,string Imagequestion, string refNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
          var  question = Imagequestion;
            var userName = objComplex.Username;
            var image  = dat;
            var res = await PalletService.SetImageAsync(refNo, question, userName, image);
           return  Json(res);
        }

    }
}
