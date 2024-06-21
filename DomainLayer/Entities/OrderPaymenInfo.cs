using DomainLayer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entities
{
    public class OrderPaymenInfo:BaseEntity
    {
        public string OrderCode { get; set; }
        public Order Order { get; set; }

        public string PaymentMethod { get; set; }

        public string TotalPrice { get; set; }
        public bool BankPayment { get; set; }
        public bool CashbackPayment { get; set; }

        public bool CertificatePayment { get; set; }

        public string BankNumber { get; set; }
        public string CashbackTransactionNumber { get; set; }
        public string CertificateNumber { get; set; }





    }
}
