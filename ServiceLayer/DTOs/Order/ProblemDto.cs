using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Order
{
    public class ProblemDto
    {
        public OrderEditDto? OrderEditDto { get; set; }
        public CommentDto? CommentDto { get; set; }
        public OrderStatusEditDto? OrderStatuses { get; set; }

        [BindProperty]
        public List<OrderItemsDto>? OrderItemsDto { get; set; }= new List<OrderItemsDto>();
    }
}
