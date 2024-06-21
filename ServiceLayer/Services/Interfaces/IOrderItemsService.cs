using DomainLayer.Entities;
using ServiceLayer.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IOrderItemsService
    {
        Task CreateAsync(OrderItemsCreateDto orderItemsDto);

        Task UpdateAsync(string Id, OrderItemsEditDto orderItemsEditDto);
        Task UpdateConfirmAsync(string Id, OrderItemsEditDto orderItemsEditDto);
        Task UpdateNotConfirmAsync(string Id, OrderItemsEditDto orderItemsEditDto);
        Task UpdateReturnIsAccountingAsync(string Id, OrderItemsEditDto orderItemsEditDto);
        Task UpdateIsCheckedAngarAsync(string Id);


        Task DeleteAsync(string id);
        Task<List<OrderItemsDto>> GetAllAsync();
        Task<OrderItemsEditDto> GetAsync(string id);
        //Task<OrderItemsEditDto> GetOrderInOrderITems(string Id);
    }
}
