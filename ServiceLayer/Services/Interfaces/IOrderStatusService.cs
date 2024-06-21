using ServiceLayer.DTOs.OrderPaymentInfo;
using ServiceLayer.DTOs.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderStatusService
    {
        Task CreateAsync(OrderStatusDto orderStatusDto);

        Task UpdateAsync(string Id, OrderStatusEditDto orderStatusEditDto);
        Task DeleteAsync(string id);
        Task<List<OrderStatusDto>> GetAllAsync();
        Task<OrderStatusEditDto> GetAsync(string id);

        Task UpdateOrderStatusAsync(string Id, OrderStatusEditDto orderStatusEditDto);
        Task UpdateOrderStatusAccountingAsync(string Id, OrderStatusEditDto orderStatusEditDto);
        Task UpdateOrderStatusReturnAccountingAsync(string Id, OrderStatusEditDto orderStatusEditDto);
        Task UpdateOrderStatusAngarAsync(string Id, OrderStatusEditDto orderStatusEditDto);
        Task UpdateOrderStatusNotDeliveredAsync(string Id, OrderStatusEditDto orderStatusEditDto);
        Task UpdateOrderStatusHalfAssembledAsync(string Id, OrderStatusEditDto orderStatusEditDto);
        Task UpdateOrderStatusAllAssembledAsync(string Id, OrderStatusEditDto orderStatusEditDto);
        Task UpdateOrderStatusAngarRussianAsync(string Id);
        Task UpdateOrderStatusComplatedOrderAsync(string Id);
    }
}
