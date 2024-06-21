using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderPaymentInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.OrderOrderItemPaymentInfoCreate
{
    public class OrderPaymentItem
    {
        public OrderCreateDto OrderCreate { get; set; }
        public OrderPaymentInfoCreateDto OrderPaymentInfoCreate { get; set; }
        public List<OrderItemsCreateDto> OrderItems { get; set; }
    }
}
