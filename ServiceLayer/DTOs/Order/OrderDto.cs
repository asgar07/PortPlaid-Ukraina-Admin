using DomainLayer.Entities;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderPaymentInfo;
using ServiceLayer.DTOs.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Order
{
    public class OrderDto
    {
        public string? AppUserId { get; set; }
        public string Id { get; set; }
        public string? UserId { get; set; }
        public string? UserPhoneNumber { get; set; }
        public string? UserEmail { get; set; }


        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string OrderCode { get; set; }
        public string PostName { get; set; }
        public string City { get; set; }
        public string PostOffice { get; set; }
        public string DeliveryClientName { get; set; }
        public string DeliveryClientPhoneNumber { get; set; }
        public float TotalPrice { get; set; }
        public float WeightFirst { get; set; }
        public float? WeightEnd { get; set; }
        public float TotalProductPrice { get; set; }
        public float TotalDeliveryPrice { get; set; }
        public int ProductCount { get; set; }

        public bool? IsProblem { get; set; }
        public UserDto? Manager { get; set; }
        public string? ManagerId { get; set; }

        public List<OrderItemsDto>? OrderItems { get; set; }
     
        public string OrderPaymenInfoId { get; set; }
        public OrderPaymentInfoDto? OrderPaymenInfo { get; set; }
        public List<CommentDto>? Comments { get; set; }

        public CommentDto? Commentari { get; set; }
        public OrderStatusDto? OrderStatuses { get; set; }
        public DateTime? CreatTime { get; set; }


    }
}
