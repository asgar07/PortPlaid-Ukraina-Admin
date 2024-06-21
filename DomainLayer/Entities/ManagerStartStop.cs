using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class ManagerStartStop:BaseEntity
    {
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public List<Order> Orders { get; set; }

    }
}
