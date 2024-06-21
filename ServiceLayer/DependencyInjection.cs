using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services.Interfaces;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class DependencyInjection
    {


        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderItemsService, OrderItemsService>();
            services.AddScoped<IOrderPaymentInfoService, OrderPaymentInfoService>();
            services.AddScoped<IOrderStatusService, OrderStatusService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IManagerStartStopService, ManagerStartStopService>();


            return services;
        }
    }
}
