using Brandhub.Business.Interface;
using Brandhub.Business.Services;
using BrandHub.Map.Models;
using Microsoft.AspNetCore.Mvc;

namespace BrandHub.Controllers
{
    public class PalletNumber : Controller
    {
       public  string reference;
        IHttpContextAccessor context;
        private readonly IPalletServices PalletService;
        public PalletNumber(IHttpContextAccessor context, IPalletServices _palletService)
        {
            this.context = context;
            PalletService = _palletService;
        }

        public IActionResult Index(string refNo)
        {
          
            this.reference = refNo;
            ViewBag.refer = this.reference;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SetAnswer(string answer,string question,string refNo)
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            string userName = objComplex.Username;
            string resp= await PalletService.SetAnswerAsync(refNo, question, userName, answer);
            return Json(resp);
        }


    }
}
