using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Comment
{
    public class CommentEditDto
    {
        public string Id { get; set; }
        public string? OrderId { get; set; }

        public OrderDto? Order { get; set; }
        public string? OrderItemId { get; set; }

        public OrderItemsDto? OrderItems { get; set; }


        public DateTime? GetStarted { get; set; }
        public string? Department { get; set; }

        public DateTime? ChangeStatusTime { get; set; }
        public string? ChangeStatusName { get; set; }
        public string? CommenterName { get; set; }
        public string? Comment { get; set; }
        public bool? IsCard { get; set; }
        public string? BankCard { get; set; }
        public string? ReturnPrice { get; set; }
        public string? ReturnMethod { get; set; }

    }
}
