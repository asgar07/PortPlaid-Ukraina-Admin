using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Order> entities;

        public OrderRepository(AppDbContext context) : base(context)
        {
            _context = context;
            entities = context.Set<Order>();
        }

        public async Task<List<Order>> GetAllOrdersInUsers()
        {

            return await entities.Where(m => m.SoftDelete == false).Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).Include(m => m.Comments.OrderByDescending(m => m.CreatTime)).ToListAsync();


        }
        

        public async Task<Order> GetOrderInUserAsync(string id)
        {
            return await entities.Where(m => m.SoftDelete == false && m.Id == id).Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).Include(m => m.Comments.OrderByDescending(m => m.CreatTime)).FirstOrDefaultAsync();
        }

        public async Task<List<Order>> GetDepartmentManagerAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "Manager").Where(m=>m.AppUserId==null).Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).Include(m => m.Comments.OrderByDescending(m => m.CreatTime)).ToListAsync();
        }

        public async Task<List<Order>> GetDepartmentProblemAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "ProblemSolving").Where(m=>m.IsProblem==true).Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).Include(m => m.Comments.OrderByDescending(m => m.CreatTime)).ToListAsync();

        }

        public async Task<List<Order>> GetDepartmentReturnAccountingAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "ReturnAccounting").Where(m => m.IsProblem == true).Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).ToListAsync();

        }

        public async Task<List<Order>> GetDepartmentAccountingAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "Accounting").Where(m => m.IsProblem == true).Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).ToListAsync();

        }
        public async Task<List<Order>> GetDepartmentResolvedAsync()
        {
            return await entities.Where(m => m.SoftDelete == false &&m.IsProblem==true).Where(m => m.OrderStatuses.Department == "Angar" || m.OrderStatuses.Department == "Refused").Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).ToListAsync();

        }
        public async Task<List<Order>> GetDepartmentAngarAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "Angar").Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).ToListAsync();

        }


        public async Task<List<Order>> GetDepartmentHalfAssambledAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "HalfAssembled").Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).ToListAsync();

        }

        public async Task<List<Order>> GetDepartmentAllAssambledAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "AllAssembled")
                .Include(m => m.Manager)
                .Include(m => m.OrderPaymenInfo)
                .Include(m => m.OrderItems)
                .Include(m => m.OrderStatuses)
                .ToListAsync();

        }


        public async Task<List<Order>> GetDepartmentAngarRussianWaitingAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "AngarRussian")
                .Include(m => m.Manager)
                .Include(m => m.OrderPaymenInfo)
                .Include(m => m.OrderItems)
                .Include(m => m.OrderStatuses)
                .ToListAsync();

        }


        public async Task<List<Order>> GetDepartmentAngarRussianAssembledAsync()
        {
            return await entities.Where(m => m.SoftDelete == false && m.OrderStatuses.Department == "AngarRussianComplated").Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).ToListAsync();

        }



        public async Task<Order> FindDeliveryCodeAsync(Expression<Func<Order, bool>> predicate)
        {
            return await entities.Where(m => m.SoftDelete == false).Where(predicate).Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems.Where(m=>m.ConfirmSuccess==true && m.CheckProduct==true)).Include(m => m.OrderStatuses).FirstOrDefaultAsync();
        }

        public async Task<Order> FindOrderCodeAsync(Expression<Func<Order, bool>> predicate)
        {
            return await entities.Where(m => m.SoftDelete == false).Where(predicate).Include(m => m.Manager).Include(m => m.OrderPaymenInfo).Include(m => m.OrderItems).Include(m => m.OrderStatuses).FirstOrDefaultAsync();

        }

        public async Task<bool> CheckOrderComplated(string deliveryCode)
        {
            var order = entities
                        .Where(o => o.OrderItems.Any(oi => oi.DeliveryCode == deliveryCode))
                        .FirstOrDefault();
            var isComplated = order.OrderItems.All(oi => oi.IsAngarCheck == true);
            return isComplated;
        }
    }
}