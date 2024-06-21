using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Comment
{
    public class CommentDto
    {
        public string? Id { get; set; }
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
        [MaxLength(16,ErrorMessage ="Bank Card Digit With 16")]
        [MinLength(16, ErrorMessage = "Bank Card Digit With 16")]
        public string? BankCard { get; set; }
        public string? ReturnPrice { get; set; }
        public string? ReturnMethod { get; set; }

        [NotMapped]
        public bool? NotificateUser { get; set; }

        [NotMapped]
        public bool? SendAngar { get; set; }


    }
}
