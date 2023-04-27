

using Newtonsoft.Json;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;

using BrandHub.Map.Models.Dto;
using BrandHub.Map.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.IdentityModel.Tokens;
using Brandhub.Business.Interface;
using Microsoft.Extensions.Configuration;

namespace Brandhub.Business.Services
{
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }

    public class AthenticationService : IAuthenticationService
    {


        private readonly string BaseUrl;
        private readonly IHttpContextAccessor context;
        public AthenticationService(IHttpContextAccessor _context, IConfiguration configuration)
        {
            context = _context;
            //  var appBaseUrl = MyHttpContext.AppBaseUrl;
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

        public async Task<string> LoginAsync(ValidatingLoginDto Newuser)
        {

            UserModel user = new UserModel();
            string ErrorDetail = "";
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(Newuser), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(BaseUrl + "/Order/Login/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<UserModel>(apiResponse);
                    if (!string.IsNullOrEmpty(user.errText))
                    {
                        return user.errText;
                    }
                    LoginSessionObject ResponseObject = new LoginSessionObject();
                    ResponseObject.Username = user.Username;
                    ResponseObject.allowDispatch = user.allowDispatch;
                    ResponseObject.allowReturns = user.allowReturns;
                    ResponseObject.allowGoodsIn = user.allowGoodsIn;
                    ResponseObject.allowSecurity = user.allowSecurity;
                    ResponseObject.allowInventoryControl = user.allowInventoryControl;
                    context.HttpContext.Session.SetObject("LoginSession", ResponseObject);
                    ErrorDetail = user.errDetail;

                }
            }

            return ErrorDetail;
        }


    }
}