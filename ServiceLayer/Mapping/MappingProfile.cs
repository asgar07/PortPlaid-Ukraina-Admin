using AutoMapper;
using DomainLayer.Entities;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.ManagerStartStop;
using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderPaymentInfo;
using ServiceLayer.DTOs.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<AppUser, RegisterDto>().ReverseMap();
            CreateMap<AppUser, LoginDto>().ReverseMap();
            CreateMap<AppUser, UserDto>().ReverseMap();

            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, OrderEditDto>().ReverseMap();
            CreateMap<OrderItems, OrderItemsDto>().ReverseMap();
            CreateMap<OrderItems, OrderItemsEditDto>().ReverseMap();
            CreateMap<OrderPaymenInfo, OrderPaymentInfoDto>().ReverseMap();
            CreateMap<OrderPaymenInfo, OrderPaymentInfoEditDto>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusDto>().ReverseMap();
            CreateMap<OrderStatus, OrderStatusEditDto>().ReverseMap();



            CreateMap<Comments, CommentDto>().ReverseMap();
            CreateMap<Comments, CommentEditDto>().ReverseMap();

            CreateMap<ManagerStartStop, ManagerStartStopDto>().ReverseMap();
            CreateMap<ManagerStartStop, ManagerStartStopEditDto>().ReverseMap();


            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<OrderItems, OrderItemsCreateDto>().ReverseMap();
            CreateMap<OrderPaymenInfo, OrderPaymentInfoCreateDto>().ReverseMap();

        }
    }
}
