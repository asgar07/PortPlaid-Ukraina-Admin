using DomainLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderStatus;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System.Data;
using System.Security.Claims;

namespace PortPlaid.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly IOrderItemsService _orderItemsService;
        private readonly ICommentService _commentService;
        private readonly IOrderStatusService _orderStatusService;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(IOrderService service, 
            IOrderItemsService orderItemsService, 
            ICommentService commentService, 
            IOrderStatusService orderStatusService,
            UserManager<AppUser> userManager)
        {
            _service = service;
            _orderItemsService = orderItemsService;
            _commentService = commentService;
            _orderStatusService = orderStatusService;
            _userManager = userManager;
        }

        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Index()
        {

            var orders= await _service.GetDepartmentManagerAsync();
            return View(orders);
        }


        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetOrderInOrderItems(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);
        
        }
        

        [HttpPost]
        [Route("/GetConfirmOrderItem")]
        public async Task GetConfirmOrderItem([FromHeader] string orderitemsid, [FromHeader] string transactioncode, [FromHeader] string deliverycode)
        {
            OrderItemsEditDto orderItemsEdit = new OrderItemsEditDto
            {
                Id = orderitemsid,
                TransactionCode=transactioncode,
                DeliveryCode=deliverycode,
            };

            await _orderItemsService.UpdateConfirmAsync(orderItemsEdit.Id, orderItemsEdit);
            //return RedirectToAction("Index" ,"Order");

        }

        [HttpPost]
        public async Task AddTimeComment(string orderid)
        {

          
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userRole= _userManager.GetUsersInRoleAsync(userId);
            var user = await _userManager.FindByIdAsync(userId);
            CommentDto commentDto = new CommentDto
            {
                OrderId = orderid,
                GetStarted = DateTime.UtcNow.AddHours(4),
                CommenterName = user?.Name,
            };

            await _commentService.CreateAsync(commentDto);


           

            await _service.UpdateManagerIdInOrderAsync(orderid, userId);

        }

        [HttpPost]
        //[Route("/AddProductProblemSolving")]
        public async Task<IActionResult> AddProductProblemSolving(ProblemDto problemDto,OrderEditDto orderItemsDto)
        {

            foreach (var item in orderItemsDto.OrderItems)
            {
                if (item.ConfirmSuccess ==true)
                {
                   var model= await _orderItemsService.GetAsync(item.Id);
                    await _orderItemsService.UpdateConfirmAsync(model.Id, model);
                }
                else
                {
                    var model = await _orderItemsService.GetAsync(item.Id);
                    await _orderItemsService.UpdateNotConfirmAsync(model.Id, model);
                }
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            problemDto.CommentDto.ChangeStatusName = "проблемные";
            problemDto.CommentDto.CommenterName = user?.Name;
            problemDto.CommentDto.Department = "Manager";


            await _commentService.CreateAsync(problemDto.CommentDto);

            

        
             
           


            await _orderStatusService.UpdateOrderStatusAsync(problemDto.OrderStatuses.Id, problemDto.OrderStatuses);

            await _service.UpdateOrderIsProblemmingAsync(problemDto.OrderEditDto.Id);



            return  RedirectToAction("Index", "Order");

        }

        [HttpPost]
        [Route("/StartManagerSession")]
        public async Task<IActionResult> StartManagerSession()
        {
            var userId = User.Identity.Name;
            await _service.StartMangerSession(userId);
            return Ok();
        }

        [HttpPost]
        [Route("/StopManagerSession")]
        public async Task<IActionResult> StopManagerSession()
        {
            var userId = User.Identity.Name;
            await _service.StopMangerSession(userId);
            return Ok();
        }
        [HttpPost]
        [Route("/CheckOrderId/{orderId}")]
        public async Task<IActionResult> CheckOrder([FromRoute] string orderId)
        {
            var userId = User.Identity.Name;
            var data = await _service.CheckOrder(orderId, userId);
            await AddTimeComment(orderId);
            return Ok(data);
        } 

        //[Route("/AddProductProblemSolving")]
        public async Task<IActionResult> SendAccountingArea(ProblemDto problemDto, OrderEditDto orderItemsDto)
        {

            foreach (var item in orderItemsDto.OrderItems)
            {
                if (item.ConfirmSuccess == true)
                {
                    var model = await _orderItemsService.GetAsync(item.Id);
                    await _orderItemsService.UpdateConfirmAsync(model.Id, model);
                }
                else
                {
                    var model = await _orderItemsService.GetAsync(item.Id);
                    await _orderItemsService.UpdateNotConfirmAsync(model.Id, model);
                }
            }


            //if (problemDto.CommentDto.IsCard==true)
            //{

            //problemDto.CommentDto.ReturnMethod = "На Карту";
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            problemDto.CommentDto.ChangeStatusName = "бухалтер";
            problemDto.CommentDto.CommenterName = user?.Name;
            problemDto.CommentDto.Department = "проблем менеджер";
            await _commentService.CreateAsync(problemDto.CommentDto);
            //}
            //else
            //{
            //    problemDto.CommentDto.ReturnMethod = "Кешбек";
            //    await _commentService.CreateAsync(problemDto.CommentDto);
            //}

        

            var order = await _service.GetAsync(problemDto.OrderEditDto.Id);






            await _orderStatusService.UpdateOrderStatusAccountingAsync(problemDto.OrderStatuses.Id, problemDto.OrderStatuses);



            return RedirectToAction("ProblemAreaIndex", "Order");

        }
        [HttpPost]
        //[Route("/AddProductProblemSolving")]
        public async Task<IActionResult> ReturnAccountingIsProblem(ProblemDto problemDto, OrderEditDto orderItemsDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            problemDto.CommentDto.CommenterName = user?.Name;
            problemDto.CommentDto.ChangeStatusName = "return account problem solving";
            problemDto.CommentDto.Department = "Accounting";
            problemDto.CommentDto.ChangeStatusTime = DateTime.UtcNow;
            await _commentService.CreateAsync(problemDto.CommentDto);
          

            await _orderStatusService.UpdateOrderStatusReturnAccountingAsync(problemDto.OrderStatuses.Id, problemDto.OrderStatuses);



            return RedirectToAction("AccountingAreaIndex", "Order");

        }

        [HttpPost]
        public async Task<IActionResult> ResolveProblem(ProblemDto problemDto, OrderEditDto orderItemsDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            problemDto.CommentDto.ChangeStatusName = "resolve problem";
            problemDto.CommentDto.CommenterName = user?.Name;
            problemDto.CommentDto.Department = "ProblemSolving";
            problemDto.CommentDto.ChangeStatusTime = DateTime.UtcNow;


            await _commentService.CreateAsync(problemDto.CommentDto);


            if (problemDto.CommentDto.NotificateUser==true)
            {

            }

            if (problemDto.CommentDto.SendAngar == true)
            {
                await _orderStatusService.UpdateOrderStatusAngarAsync(problemDto.OrderStatuses.Id, problemDto.OrderStatuses);

            }
            else
            {
                await _orderStatusService.UpdateOrderStatusAngarAsync(problemDto.OrderStatuses.Id, problemDto.OrderStatuses);

            }






            return RedirectToAction("AccountingAreaIndex", "Order");

        }




        [HttpPost]
        public async Task<IActionResult> ManagerSendAngarOrder(ProblemDto problemDto, OrderEditDto orderItemsDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            problemDto.CommentDto.ChangeStatusName = "Angar";
            problemDto.CommentDto.CommenterName = user?.Name;
            problemDto.CommentDto.Department = "Manager";
            problemDto.CommentDto.ChangeStatusTime = DateTime.UtcNow;


            await _commentService.CreateAsync(problemDto.CommentDto);


            if (problemDto.CommentDto.NotificateUser == true)
            {

            }

            if (problemDto.CommentDto.SendAngar == true)
            {
                await _orderStatusService.UpdateOrderStatusAngarAsync(problemDto.OrderStatuses.Id, problemDto.OrderStatuses);

            }
            else
            {
                await _orderStatusService.UpdateOrderStatusAngarAsync(problemDto.OrderStatuses.Id, problemDto.OrderStatuses);

            }






            return RedirectToAction("Index", "Order");

        }
        public async Task<IActionResult> ProblemAreaIndex()
        {
            var orders = await _service.GetDepartmentAccountingAsync();
            return View(orders);
        }

        public async Task<IActionResult> ProblemWaiting()
        {
            var orders = await _service.GetDepartmentProblemAsync();
            return View(orders);
        }

        public async Task<IActionResult> ProblemWaitingReturnAccounting()
        {
            var orders = await _service.GetDepartmentAccountingAsync();
            return View(orders);
        }

        public async Task<IActionResult> ProblemWaitingReturnAccountingDetail(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);
        }

        public async Task<IActionResult> Resolved()
        {
            var orders = await _service.GetDepartmentResolvedAsync();
            return View(orders);
        }

        public async Task<IActionResult> ResolvedDetail(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);
        }

        public async Task<IActionResult> ReturnAccounting()
        {
            var orders = await _service.GetDepartmentReturnAccountingAsync();
            return View(orders);
        }


        public async Task<IActionResult> GetHandleProblem(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);

        }

       


        public async Task<IActionResult> AccountingAreaIndex()
        {
            var orders = await _service.GetDepartmentAccountingAsync();
            return View(orders);
        }

        public async Task<IActionResult> GetHandleAccounting(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);

        }

        public async Task<IActionResult> GetHandleReturnAccounting(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);

        }



        //public async Task<IActionResult> ProblemOrder(string orderId)
        //{
        //    var order = _service.GetAsync(orderId);
        //    order.Status = _context.OrderStaus.Where(mbox => mbox.Status = "Problem");

        //    return View(order);
        //}


        #region Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Create(OrderDto orderDto)
        //{
        //    await _service.CreateAsync(orderDto);
        //    return RedirectToAction("Index", "Order");
        //}
      
        //[HttpPost]
        //[Route("api/Order/CreateOrder")]
        ////[Authorize(Roles = "SuperAdmin,Admin")]
        //public async Task<IActionResult> Create([FromBody] OrderDto orderDto)
        //{
        //    await _service.CreateAsync(orderDto);
        //    return Ok();
        //}
        #endregion


        public async Task<IActionResult> AngarTurkeyIndex()
        {
           
            return View();
        }

        public async Task<IActionResult> AngarTurkeyWaiting()
        {
            var orders = await _service.GetDepartmentAngarAsync();
            return View(orders);
        }


        public async Task<IActionResult> AngarTurkeyWaitingDetail(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);
        }
        public async Task<IActionResult> HalfAssembled()
        {
            var orders = await _service.GetDepartmentHalfAssambledAsync();
            return View(orders);
        }

        public async Task<IActionResult> AngarTurkeyHalfAssembledDetail(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);
        }

        public async Task<IActionResult> AllAssembled()
        {
            var orders = await _service.GetDepartmentAllAssambledAsync();
            return View(orders);
        }

        public async Task<IActionResult> AngarTurkeyAllAssembledDetail(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);
        }

        [HttpPost]
        [Route("/CheckDeliveryCodeInOrder")]
        public async Task CheckDeliveryCodeInOrder([FromHeader] string deliveryCode)
        {
          var model=  await _service.GetFindDeliveryCodeOrder(deliveryCode);

           


         

            foreach (var item in model.OrderItems)
            {
                if (item.IsAngarCheck!=true)
                {
                    if (item.DeliveryCode == deliveryCode)
                    {


                        await _orderItemsService.UpdateIsCheckedAngarAsync(item.Id);

                       


                        var completed = await _service.CheckOrderComplated(deliveryCode);

                        if (completed !=true)
                        {

                            OrderStatusEditDto orderStatusEditDto = new OrderStatusEditDto
                            {
                                Id = model.OrderStatuses.Id,
                                Department = "HalfAssembled",
                            };
                            await _orderStatusService.UpdateOrderStatusHalfAssembledAsync(orderStatusEditDto.Id, orderStatusEditDto);


                        }
                        else
                        {

                            OrderStatusEditDto orderStatusEditDto = new OrderStatusEditDto
                            {
                                Id = model.OrderStatuses.Id,
                                Department = "AllAssembled",
                            };
                            await _orderStatusService.UpdateOrderStatusAllAssembledAsync(orderStatusEditDto.Id, orderStatusEditDto);

                        }



                    }
                }
              
              
            }
       

        }



        public async Task<IActionResult> AngarRussianIndex()
        {

            return View();
        }

        public async Task<IActionResult> AngarRussianWaiting()
        {
            var orders = await _service.GetDepartmentAngarRussianWaitingAsync();
            return View(orders);
        }
        public async Task<IActionResult> GetAngarRussianWaitingDetail(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);

        }
        public async Task<IActionResult> AllRussianAngarAssembled()
        {
            var orders = await _service.GetDepartmentAngarRussianAssembledAsync();
            return View(orders);
        }

        public async Task<IActionResult> GetAngarRussianAllAssembledDetail(string Id)
        {
            var order = await _service.GetAsync(Id);
            return View(order);

        }
        [HttpPost]
        [Route("/CheckOrderCodeInOrder")]
        public async Task CheckOrderCodeInOrder([FromHeader] string orderCode)
        {
            var model = await _service.GetFindOrderCode(orderCode);
                      
            await _orderStatusService.UpdateOrderStatusComplatedOrderAsync(model.OrderStatuses.Id);
          
        }

        [HttpPost]
        [Route("/UpdateOrderWeight")]
        public async Task UpdateOrderWeight([FromHeader] string Id, [FromHeader] float Weight, [FromHeader] string OrderStatusId)
        {
            await _service.UpdateOrderWeight(Id, Weight);



            await _orderStatusService.UpdateOrderStatusAngarRussianAsync(OrderStatusId);




        }

        [HttpGet]
        [Route("/Search")]
        public async Task<List<OrderDto>> Search([FromHeader] string query)
        {


            var order = await _service.Search(query);
            return order;
            //return RedirectToAction("Index" ,"Order");

        }
    }

   
}
    

