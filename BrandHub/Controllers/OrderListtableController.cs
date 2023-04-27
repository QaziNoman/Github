using Brandhub.Business.Interface;
using Brandhub.Business.Services;
using BrandHub.Map.Models;
using BrandHub.Map.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace BrandHub.Controllers
{
    public class OrderListtableController : Controller
    { 
        private readonly IGetOrderServices orderServices;
        private readonly IHttpContextAccessor context;
        public OrderListtableController(IGetOrderServices _orderServices, IHttpContextAccessor _context)
        {

            orderServices = _orderServices;
            this.context = _context;
        }
        public async Task<ActionResult>  Index()
        {
            
            return View();
        }
        public async Task<ActionResult> YMSHome()
        {

            return View();
        }

        string OrderrefereneceNumber = "";
        public IActionResult PlatteCondition(string RefNo)
        {

            ViewBag.RefNo = RefNo;


            return View();
        }

        public async Task<ActionResult> UpdateOrder(String refer)
        {
            OrderSelectionModel od= new OrderSelectionModel();
            //od= orderServices.GetOrderByReferenceAsync()
            OrderDetail Order = new OrderDetail();
            string OrderrefereneceNumber = refer;
            var objComplex = context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            var order = await orderServices.GetSingleOrderDetailAsync(OrderrefereneceNumber);
            var Singleorder= await orderServices.GetOrderByReferenceAsync(OrderrefereneceNumber, objComplex.Username);
            ViewBag.customerName = Singleorder.customerName
;            Order.OrderRef = refer;
             Order.fourWayEntryPalletUK = order.fourWayEntryPalletUK;
             Order.fourWayEntryPalletEU = order.fourWayEntryPalletEU;
             Order.chepPallet = order.chepPallet;
             Order.euPallet = order.euPallet;
             Order.anyPallet = order.anyPallet;
            Order.palletType = order.palletType;
             Order.specificLabel = order.specificLabel;
             Order.customerNameOnLabel =order.customerNameOnLabel;

                Order.palletWrapped = order.palletWrapped;
                Order.labelConfirmation = order.labelConfirmation;
            Order.truePallet = new List<string>();
            if (Order.fourWayEntryPalletUK == true)
            {
                Order.truePallet.Add("fourWayEntryPalletUK");
            }
            if (Order.fourWayEntryPalletEU == true)
            {
                Order.truePallet.Add("fourWayEntryPalletEU");
            }
            if (Order.euPallet == true)
            {
                Order.truePallet.Add("euPallet");
            }
            if (Order.chepPallet == true)
            {
                Order.truePallet.Add("chepPallet");
            }
          
            //ViewBag.
            return View(Order);
        }

        [HttpPost]
        public async Task<JsonResult> QuestionSubmittion(string reference,string answer,string question)
        {
            QuestionSubmitViewModel model= new QuestionSubmitViewModel();
            var objComplex =  this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            model.orderRef = reference;
            model.userName = objComplex.Username;
            model.question = question;
            model.answer = answer;
            string resp = await orderServices.QuestionSubmition(model);
            return Json(resp);
        }

        [HttpPost]
        public async Task<JsonResult> GetAllOrder()
        {
            GetOrderDto Ordercredential = new GetOrderDto();
            List<OrderTableDto> orderlist = new List<OrderTableDto>();
            var objComplex = this.context.HttpContext.Session.GetObject<LoginSessionObject>("LoginSession");
            if (objComplex != null)
            {
                Ordercredential.UserName = objComplex.Username;
                foreach (var item in await orderServices.GetOrderAsync(Ordercredential))
                {
                    OrderTableDto order = new OrderTableDto();
                    order.customerReference = item.customerReference;
                    order.orderReference = item.orderReference;
                    order.customerName = item.customerName;
                    order.orderDate= item.orderDate;    
                    order.expectedShipDate = item.expectedShipDate;
                    order.orderStatus = item.orderStatus;
                    order.sku = item.sku;
                    order.productDescription = item.productDescription;
                    order.productType = item.productType;

                    order.qty = item.qty;
                    order.orderColor = item.orderColor;
                    orderlist.Add(order);

                }

            }
            return Json(orderlist);
        }

        [HttpPost]
        public async Task<JsonResult> GetStation()
        {
           
            List<StationList> Stlist = new List<StationList>();

         
                
                foreach (var item in await orderServices.GetStationList())
                {
                StationList Listitem = new StationList();
               Listitem.stationID = item.stationID;
                Stlist.Add(Listitem);
                }

            

            return Json(Stlist);
        }
    }
}
