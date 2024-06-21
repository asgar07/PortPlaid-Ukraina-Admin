using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class Comments:BaseEntity
    {
        public string? OrderId { get; set; }
        public Order? Order { get; set; }
        public DateTime? GetStarted { get; set; }
        public string? Department { get; set; }

        public DateTime? ChangeStatusTime { get; set; }
        public string? ChangeStatusName { get; set; }

        public string? CommenterName { get; set; }
        public string? Comment { get; set; }
        public bool? IsCard { get; set; }
        public string? ReturnMethod { get; set; }
        public string? BankCard { get; set; }
        public string? ReturnPrice { get; set; }
    
    }
}
