using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class OrderStatus:BaseEntity
    {
        public string OrderCode { get; set; }
        public string? Status { get; set; }
        public string Department { get; set; }
        public List<Order>? Orders { get; set; }

    }
}
