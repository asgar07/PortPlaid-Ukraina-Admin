using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class OrderItemStatus : BaseEntity
    {
        public string Status { get; set; }
        public List<OrderItems> OrderItems { get; set; }
    }
}
