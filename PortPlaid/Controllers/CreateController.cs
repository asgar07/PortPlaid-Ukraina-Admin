using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderOrderItemPaymentInfoCreate;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;

namespace PortPlaid.Controllers
{
    public class CreateController : Controller
    {
        private readonly IOrderItemsService _orderItemsService;
        private readonly IOrderService _orderService;
        private readonly IOrderPaymentInfoService _orderPaymentInfoService;
        public CreateController(IOrderItemsService orderItemsService, IOrderService orderService, IOrderPaymentInfoService orderPaymentInfoService)
        {
            _orderItemsService = orderItemsService;
            _orderService = orderService;
            _orderPaymentInfoService = orderPaymentInfoService;
        }

        [HttpPost]
        [Route("api/Create/CreateAllOrderPaymentOrderInOrderItems")]
        //[Authorize(Roles = "SuperAdmin,Admin")]
        public async Task<IActionResult> Create(OrderPaymentItem orderPaymentItem)
        {
            await _orderService.CreateAsync(orderPaymentItem.OrderCreate);

            await _orderPaymentInfoService.CreateAsync(orderPaymentItem.OrderPaymentInfoCreate);

            foreach (var item in orderPaymentItem.OrderItems)
            {
                await _orderItemsService.CreateAsync(item);

            }

            return Ok();
        }
    }
}
