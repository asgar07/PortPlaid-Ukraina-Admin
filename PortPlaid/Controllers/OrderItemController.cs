using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.Services.Interfaces;

namespace PortPlaid.Controllers
{
    public class OrderItemController : Controller
    {
        private readonly IOrderItemsService _service;
        public OrderItemController(IOrderItemsService service)
        {

            _service = service;
        }
        public async Task<IActionResult> OrderCheck(string Id)
        {
            
            return View();
        }

        //[HttpPost]
        //[Route("api/OrderItem/CreateOrderItem")]
        ////[Authorize(Roles = "SuperAdmin,Admin")]
        //public async Task<IActionResult> Create([FromBody] OrderItemsDto orderItemsDto)
        //{
        //    await _service.CreateAsync(orderItemsDto);
        //    return Ok();
        //}
    }
}
