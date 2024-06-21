using ServiceLayer.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.OrderItems
{
    public class OrderItemsCreateDto
    {
        public string? Id { get; set; }
        public string OrderId { get; set; }
        public string ProductImage { get; set; }
        public string ProductName { get; set; }
        public float ProductPriceLira { get; set; }
        public float ProductPriceRubl { get; set; }
        public string ProductLink { get; set; }
        public string ProductColor { get; set; }
        public string ProductSize { get; set; }

    }
}
