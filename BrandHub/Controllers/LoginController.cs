using Brandhub.Business.Interface;
using Brandhub.Business.Services;
using BrandHub.Map.Models;
using BrandHub.Map.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BrandHub.Controllers
{

    public class LoginController : Controller
    {
        private readonly IAuthenticationService Authentication_Services;
        private readonly IHttpContextAccessor context;
        public LoginController(IAuthenticationService authentication_Services, IHttpContextAccessor _context)
        {

            Authentication_Services = authentication_Services;
            this.context = _context;
        }

        public IActionResult Index()
        {
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            if (objComplex != null)
            {
                return RedirectToAction("Index", "OrderListtable");
            }
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> LoginPost(UserModel user)
        {

            ValidatingLoginDto User = new ValidatingLoginDto();
            User.UserName = user.Username;
            User.stationID = "";
            User.orderRef = "";
            User.qty = 0;
            User.pin = user.Password;
            HttpContext.Session.SetString("typeId", user.typeId.ToString());
            string errortext = await Authentication_Services.LoginAsync(User);
            if (!string.IsNullOrEmpty(errortext))
            {
                TempData["Status"] = errortext;
                TempData["typeId"] = user.typeId; ;
                return View();
            }

            else
            {
                var objComplex = HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
                if (objComplex == null) { Console.WriteLine(0); }
                if (user.typeId == 0)
                {
                    return RedirectToAction("Index", "OrderListtable");
                }
                else
                {
                    return RedirectToAction("Index", "YMS");
                }

            }



        }
    }

    }
      

