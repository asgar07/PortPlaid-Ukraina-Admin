using DomainLayer.Entities;
using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderService
    {
        Task CreateAsync(OrderCreateDto orderDto);

        Task UpdateAsync(string Id, OrderEditDto orderEditDto);


        Task UpdateOrderIsProblemmingAsync(string Id);
        Task UpdateManagerIdInOrderAsync(string Id, string managerId);
        Task DeleteAsync(string id);
        Task<List<OrderDto>> GetAllAsync();
        Task<List<OrderDto>> Search(string query);
        Task<List<OrderDto>> GetDepartmentManagerAsync();
        Task<List<OrderDto>> GetDepartmentProblemAsync();
        Task<List<OrderDto>> GetDepartmentReturnAccountingAsync();
        Task<List<OrderDto>> GetDepartmentAccountingAsync();
        Task<List<OrderDto>> GetDepartmentResolvedAsync();
        Task<List<OrderDto>> GetDepartmentAngarAsync();
        Task<OrderEditDto> GetAsync(string id);
        Task StartMangerSession(string userId);
        Task StopMangerSession(string userId);
        Task<string> CheckOrder(string orderId, string userName);
        //Task ChangeOrderStatusProblemAsync(string Id, OrderEditDto orderEditDto);

      Task UpdateOrderWeight(string Id, float Weight);


        Task<OrderDto> GetFindDeliveryCodeOrder(string deliveryCode);
        Task<bool> CheckOrderComplated(string deliveryCode);

        Task<OrderDto> GetFindOrderCode(string orderCode);

        Task<List<OrderDto>> GetDepartmentAngarRussianWaitingAsync();
        Task<List<OrderDto>> GetDepartmentAngarRussianAssembledAsync();

        Task<List<OrderDto>> GetDepartmentHalfAssambledAsync();
        Task<List<OrderDto>> GetDepartmentAllAssambledAsync();
    }
}
