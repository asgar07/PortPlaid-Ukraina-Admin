using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Repositories.Interfaces;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddRepositoryLayer(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemsRepository, OrderItemsRepository>();
            services.AddScoped<IOrderPaymentInfoRepository, OrderPaymentInfoRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IManagerStartStopRepository, ManagerStartStopRepository>();











            return services;
        }
    }
}
