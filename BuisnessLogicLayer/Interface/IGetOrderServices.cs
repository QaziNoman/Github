using BrandHub.Map.Models;
using BrandHub.Map.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brandhub.Business.Interface
{
    public interface IGetOrderServices
    {
        public Task<OrderSelectionModel> GetOrderByReferenceAsync(string _GetOrderDto, string userName);
        public Task<IEnumerable<OrderSelectionModel>> GetOrderAsync(GetOrderDto _GetOrderDto);
        public Task<IEnumerable<StationList>> GetStationList();
        public Task<OrderDetail> GetSingleOrderDetailAsync(string ReferenceNo);
        public Task<string> QuestionSubmition(QuestionSubmitViewModel re);
    }
}
