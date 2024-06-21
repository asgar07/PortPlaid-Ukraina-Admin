using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<List<Order>> GetAllOrdersInUsers();
        Task<Order> GetOrderInUserAsync(string id);
        Task<List<Order>> GetDepartmentManagerAsync();
        Task<List<Order>> GetDepartmentProblemAsync();
        Task<List<Order>> GetDepartmentReturnAccountingAsync();
        Task<List<Order>> GetDepartmentAccountingAsync();
        Task<List<Order>> GetDepartmentAngarAsync();
        Task<List<Order>> GetDepartmentResolvedAsync();
        Task<Order> FindDeliveryCodeAsync(Expression<Func<Order, bool>> predicate);
        Task<Order> FindOrderCodeAsync(Expression<Func<Order, bool>> predicate);
        Task<bool> CheckOrderComplated(string deliveryCode);
        Task<List<Order>> GetDepartmentAngarRussianWaitingAsync();
        Task<List<Order>> GetDepartmentAngarRussianAssembledAsync();

        Task<List<Order>> GetDepartmentHalfAssambledAsync();
        Task<List<Order>> GetDepartmentAllAssambledAsync();
    }

}
