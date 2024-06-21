using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class OrderItemsRepository : Repository<OrderItems>, IOrderItemsRepository
    {


        public OrderItemsRepository(AppDbContext context) : base(context)
        {
     
        }

        //public async Task<OrderItems> GetOrderInOrderITems(string Id)
        //{
        //    return await entities.Where(m => m.Order.Id == Id).Include(m=>m.Order).ToListAsync();
        //}
    }
}
