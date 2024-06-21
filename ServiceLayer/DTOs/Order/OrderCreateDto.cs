using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs.Order
{
    public class OrderCreateDto
    {
        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? UserPhoneNumber { get; set; }
        public string? UserEmail { get; set; }

        public bool? IsProblem { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string OrderCode { get; set; }
        public string PostName { get; set; }
        public string City { get; set; }
        public string PostOffice { get; set; }
        public string DeliveryClientName { get; set; }
        public string DeliveryClientPhoneNumber { get; set; }
        public float TotalPrice { get; set; }
        public float WeightFirst { get; set; }
        public float? WeightEnd { get; set; }
        public float TotalProductPrice { get; set; }
        public float TotalDeliveryPrice { get; set; }
        public int ProductCount { get; set; }

    }
}
