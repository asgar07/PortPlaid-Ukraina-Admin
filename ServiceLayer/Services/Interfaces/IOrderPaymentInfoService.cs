using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderPaymentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderPaymentInfoService
    {
        Task CreateAsync(OrderPaymentInfoCreateDto orderPaymentInfoDto);

        Task UpdateAsync(string Id, OrderPaymentInfoEditDto orderPaymentInfoEditDto);
        Task DeleteAsync(string id);
        Task<List<OrderPaymentInfoDto>> GetAllAsync();
        Task<OrderPaymentInfoEditDto> GetAsync(string id);
    }
}
