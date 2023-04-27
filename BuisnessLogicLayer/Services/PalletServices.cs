using Brandhub.Business.Interface;
using BrandHub.Map.Models;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandhub.Business.Services
{
    public class PalletServices : IPalletServices
    {
        private readonly string BaseUrl;
        public PalletServices(IConfiguration configuration)
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
        public async Task<string> SetImageAsync(string ReferenceNo, string question, string userName, string image)
        {

            SaveImage modelData = new SaveImage();
            modelData.orderRef = ReferenceNo;
            modelData.question = question;
            modelData.userName = userName;
            modelData.image = image;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(modelData), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(BaseUrl+"/Order/SetImage", content))
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

        public async Task<string> SetAnswerAsync(string ReferenceNo, string question, string userName, string answer)
        {

            SetAnswer modelData = new SetAnswer();
            modelData.orderRef = ReferenceNo;
            modelData.question = question;
            modelData.userName = userName;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(modelData), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(BaseUrl + "/Order/SetAnswer", content))
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
    }
}
