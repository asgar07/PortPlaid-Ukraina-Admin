using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.OrderItems
{
    public class OrderItemsEditDto
    {
        public string? Id { get; set; }
        public string? OrderId { get; set; }
        public OrderDto Order { get; set; }
        public string ProductImage { get; set; }
        public string? ProductName { get; set; }
        public float? ProductPriceLira { get; set; }
        public float? ProductPriceRubl { get; set; }
        public string? ProductLink { get; set; }
        public string? ProductColor { get; set; }
        public string? ProductSize { get; set; }
        public string? DeliveryCode { get; set; }
      
        public string? TransactionCode { get; set; }
        public bool? ConfirmSuccess { get; set; }

        public bool? CheckProduct { get; set; }
        public bool? IsAngarCheck { get; set; }

        public OrderStatusDto? OrderStatus { get; set; }

    }
}
