using BrandHub.Map.Models;
using BrandHub.Map.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Brandhub.Business.Interface;
using Microsoft.Extensions.Configuration;

namespace Brandhub.Business.Services
{
    public class GetOrderServices : IGetOrderServices
    {

        private readonly IHttpContextAccessor context;
        private readonly string BaseUrl;
        public GetOrderServices(IConfiguration configuration)
        {
            var appBaseUrl = configuration["AppUrl:AppBaseUrl"];

            if (appBaseUrl == configuration["ApiUrl:ProdBaseUrl"])
            {
                BaseUrl = configuration["ApiUrl:ProdBaseUrl"];
            }
            else
            {
                BaseUrl = configuration["ApiUrl:DevBaseUrl"];
            }
        }
        public async Task<IEnumerable<OrderSelectionModel>> GetOrderAsync(GetOrderDto _GetOrderDto)
        {

            //OrderSelectionModel Order = new OrderSelectionModel();
            List<OrderSelectionModel> OrderList = new List<OrderSelectionModel>();
            using (var httpClient = new HttpClient())
            {
                var query = new Dictionary<string, string>()
                {
                    ["UserName"] = _GetOrderDto.UserName,
                    ["Pin"] = _GetOrderDto.Pin
                };

                var uri = QueryHelpers.AddQueryString(BaseUrl+"/Order/OrderList", query);
                using (var response = await httpClient.GetAsync(uri))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var Order = JsonConvert.DeserializeObject<List<OrderSelectionModel>>(apiResponse);
                    return Order;
                }

            }


        }

        public async Task<string> QuestionSubmition(QuestionSubmitViewModel question)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(question), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(BaseUrl+"/Order/SetAnswer", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        return "Success";
                    }

                    else
                    {
                        return "failed";
                    }
                }

            }
        }

        public async Task<OrderDetail> GetSingleOrderDetailAsync(string ReferenceNo)
        {
            using (var httpClient = new HttpClient())
            {
                var query = new Dictionary<string, string>()
                {
                    ["OrderRef"] = ReferenceNo,

                };

                var uri = QueryHelpers.AddQueryString(BaseUrl+"/Order/OrderDetail", query);
                using (var response = await httpClient.GetAsync(uri))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var Order = JsonConvert.DeserializeObject<OrderDetail>(apiResponse);

                    return Order;
                }
            }
        }

        public async Task<IEnumerable<StationList>> GetStationList()
        {

            //OrderSelectionModel Order = new OrderSelectionModel();
            
            using (var httpClient = new HttpClient())
            {
                var query = new Dictionary<string, string>()
                {
                  
                };
                var uri = QueryHelpers.AddQueryString(BaseUrl+"/Order/StationList", query);
                using (var response = await httpClient.GetAsync(uri))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var StList= JsonConvert.DeserializeObject<List<StationList>>(apiResponse);

                    return StList;
                }
            }
        }

        public async Task<OrderSelectionModel> GetOrderByReferenceAsync(string _GetOrderDto, string userName)
        {
            List<OrderSelectionModel> OrderList = new List<OrderSelectionModel>();
            using (var httpClient = new HttpClient())
            {
                OrderSelectionModel order = new OrderSelectionModel();

                var query = new Dictionary<string, string>()
                {
                    ["UserName"] = userName,
                    ["orderReference"] = _GetOrderDto

                };

                var uri = QueryHelpers.AddQueryString(BaseUrl+"/Order/OrderList", query);


                using (var response = await httpClient.GetAsync(uri))
                {

                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var Orderlist = JsonConvert.DeserializeObject<List<OrderSelectionModel>>(apiResponse);
                    foreach (OrderSelectionModel i in Orderlist)
                    {
                        if (i.orderReference == _GetOrderDto)
                        {

                            order = i;
                        }
                    }

                    return order;
                }

            }
        }
    }
}
