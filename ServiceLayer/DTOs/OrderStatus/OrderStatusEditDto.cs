using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.OrderStatus
{
    public class OrderStatusEditDto
    {
        public string Id { get; set; }
        public string? OrderCode { get; set; }
        public string? Status { get; set; }
        public string? Department { get; set; }
        public List<OrderItemsDto>? OrderItems { get; set; }
    }
}
