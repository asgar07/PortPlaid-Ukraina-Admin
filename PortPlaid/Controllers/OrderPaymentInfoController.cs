using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderPaymentInfo;
using ServiceLayer.Services.Interfaces;

namespace PortPlaid.Controllers
{
    public class OrderPaymentInfoController : Controller
    {
        private readonly IOrderPaymentInfoService _service;
        public OrderPaymentInfoController(IOrderPaymentInfoService service)
        {
            _service = service;
        }

        //[HttpPost]
        //[Route("api/OrderPaymentInfo/CreateOrderPaymentInfo")]
        ////[Authorize(Roles = "SuperAdmin,Admin")]
        //public async Task<IActionResult> Create([FromBody] OrderPaymentInfoDto orderPaymentInfoDto)
        //{
        //    await _service.CreateAsync(orderPaymentInfoDto);
        //    return Ok();
        //}
    }
}
