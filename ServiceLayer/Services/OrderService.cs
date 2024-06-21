using AutoMapper;
using DomainLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.AppUser;
using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.Order;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderPaymentInfo;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly IManagerStartStopRepository _managerRepository;
        private readonly AppDbContext _context;
        private readonly DbSet<ManagerStartStop> entities;
        public OrderService(IOrderRepository repository, 
            IMapper mapper, UserManager<AppUser> userManager, 
            IManagerStartStopRepository managerRepository, 
            AppDbContext context)
        {

            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _managerRepository = managerRepository;
            _context = context;
            entities = _context.Set<ManagerStartStop>();
        }

        public async Task CreateAsync(OrderCreateDto orderDto)
        {
            orderDto.Id = Guid.NewGuid().ToString("N");


            var model = _mapper.Map<Order>(orderDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(string id)
        {
            var gallery = await _repository.GetAsync(id);
            await _repository.DeleteAsync(gallery);
        }

        public async Task<List<OrderDto>> GetAllAsync()
        {
            var model = await _repository.GetAllOrdersInUsers();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }


        public async Task<List<OrderDto>> GetDepartmentManagerAsync()
        {
            var model = await _repository.GetDepartmentManagerAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }
        public async Task<List<OrderDto>> GetDepartmentProblemAsync()
        {
            var model = await _repository.GetDepartmentProblemAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }

        public async Task<List<OrderDto>> GetDepartmentAngarAsync()
        {
            var model = await _repository.GetDepartmentAngarAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }

        public async Task<List<OrderDto>> GetDepartmentReturnAccountingAsync()
        {
            var model = await _repository.GetDepartmentReturnAccountingAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }
      

        public async Task<OrderEditDto> GetAsync(string id)
        {
            var model = await _repository.GetOrderInUserAsync(id);
            var res = _mapper.Map<OrderEditDto>(model);
            return res;
        }



        public async Task UpdateAsync(string Id, OrderEditDto orderEditDto)
        {
            var entity = await _repository.GetAsync(Id);


            if (orderEditDto.ManagerId == null)
            {
                orderEditDto.ManagerId = entity.Manager.Id;
            }
            if (orderEditDto.UserId == null)
            {
                orderEditDto.UserId = entity.UserId;
            }
            if (orderEditDto.UserName == null)
            {
                orderEditDto.UserName = entity.UserName;
            }
            if (orderEditDto.UserSurname == null)
            {
                orderEditDto.UserSurname = entity.UserSurname;
            }
            if (orderEditDto.UserEmail == null)
            {
                orderEditDto.UserEmail = entity.UserEmail;
            }
            if (orderEditDto.UserPhoneNumber == null)
            {
                orderEditDto.UserPhoneNumber = entity.UserPhoneNumber;
            }
            if (orderEditDto.OrderCode == null)
            {
                orderEditDto.OrderCode = entity.OrderCode;
            }
            if (orderEditDto.PostName == null)
            {
                orderEditDto.PostName = entity.PostName;
            }
            if (orderEditDto.City == null)
            {
                orderEditDto.City = entity.City;
            }
            if (orderEditDto.PostOffice == null)
            {
                orderEditDto.PostOffice = entity.PostOffice;
            }
            if (orderEditDto.DeliveryClientName == null)
            {
                orderEditDto.DeliveryClientName = entity.DeliveryClientName;
            }
            if (orderEditDto.DeliveryClientPhoneNumber == null)
            {
                orderEditDto.DeliveryClientPhoneNumber = entity.DeliveryClientPhoneNumber;
            }
            if (orderEditDto.TotalPrice == null)
            {
                orderEditDto.TotalPrice = entity.TotalPrice;
            }
            if (orderEditDto.WeightFirst == null)
            {
                orderEditDto.WeightFirst = entity.WeightFirst;
            }
            if (orderEditDto.WeightEnd == null)
            {
                orderEditDto.WeightEnd = entity.WeightEnd;
            }
            if (orderEditDto.TotalProductPrice == null)
            {
                orderEditDto.TotalProductPrice = entity.TotalProductPrice;
            }
            if (orderEditDto.TotalDeliveryPrice == null)
            {
                orderEditDto.TotalDeliveryPrice = entity.TotalDeliveryPrice;
            }
            if (orderEditDto.ProductCount == null)
            {
                orderEditDto.ProductCount = entity.ProductCount;
            }
            if (orderEditDto.OrderPaymenInfoId == null)
            {
                orderEditDto.OrderPaymenInfoId = entity.OrderPaymenInfoId;
            }
            _mapper.Map(orderEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        //public async Task ChangeOrderStatusProblemAsync(string Id, OrderEditDto orderEditDto)
        //{
        //    var entity = await _repository.GetAsync(Id);

        //    if (orderEditDto.UserId == null)
        //    {
        //        orderEditDto.UserId = entity.UserId;
        //    }
        //    if (orderEditDto.UserName== null)
        //    {
        //        orderEditDto.UserName = entity.UserName;
        //    }
        //    if (orderEditDto.UserSurname == null)
        //    {
        //        orderEditDto.UserSurname = entity.UserSurname;
        //    }
        //    if (orderEditDto.UserEmail == null)
        //    {
        //        orderEditDto.UserEmail = entity.UserEmail;
        //    }
        //    if (orderEditDto.UserPhoneNumber == null)
        //    {
        //        orderEditDto.UserPhoneNumber = entity.UserPhoneNumber;
        //    }
        //    if (orderEditDto.OrderCode == null)
        //    {
        //         orderEditDto.OrderCode = entity.OrderCode;
        //     }
        //     if (orderEditDto.PostName == null)
        //     {
        //         orderEditDto.PostName = entity.PostName;
        //     }
        //    if (orderEditDto.City == null)
        //    {
        //        orderEditDto.City = entity.City;
        //    }
        //    if (orderEditDto.PostOffice == null)
        //    {
        //        orderEditDto.PostOffice = entity.PostOffice;
        //    }
        //    if (orderEditDto.DeliveryClientName == null)
        //    {
        //        orderEditDto.DeliveryClientName = entity.DeliveryClientName;
        //    }
        //    if (orderEditDto.DeliveryClientPhoneNumber == null)
        //    {
        //        orderEditDto.DeliveryClientPhoneNumber = entity.DeliveryClientPhoneNumber;
        //    }
        //    if (orderEditDto.TotalPrice == null)
        //    {
        //        orderEditDto.TotalPrice = entity.TotalPrice;
        //    }
        //    if (orderEditDto.WeightFirst == null)
        //    {
        //        orderEditDto.WeightFirst = entity.WeightFirst;
        //    }
        //    if (orderEditDto.WeightEnd == null)
        //    {
        //        orderEditDto.WeightEnd = entity.WeightEnd;
        //    }
        //    if (orderEditDto.TotalProductPrice == null)
        //    {
        //        orderEditDto.TotalProductPrice = entity.TotalProductPrice;
        //    }
        //    if (orderEditDto.TotalDeliveryPrice == null)
        //    {
        //        orderEditDto.TotalDeliveryPrice = entity.TotalDeliveryPrice;
        //    }
        //    if (orderEditDto.ProductCount == null)
        //    {
        //        orderEditDto.ProductCount = entity.ProductCount;
        //    }
        //    if (orderEditDto.OrderPaymenInfoId == null)
        //    {
        //        orderEditDto.OrderPaymenInfoId = entity.OrderPaymenInfoId;
        //    }

          

        //        _mapper.Map(orderEditDto, entity);

        //    await _repository.UpdateAsync(entity);
        //}

        public async Task<List<OrderDto>> GetDepartmentAccountingAsync()
        {
            var model = await _repository.GetDepartmentAccountingAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }

        public async Task<List<OrderDto>> GetDepartmentResolvedAsync()
        {

            var model = await _repository.GetDepartmentResolvedAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }

        public async Task<OrderDto> GetFindDeliveryCodeOrder(string deliveryCode)
        {
            var res = await _repository.FindDeliveryCodeAsync(x => x.OrderItems.Any(m => m.DeliveryCode.Contains(deliveryCode)));
            var model = _mapper.Map<OrderDto>(res);
            return model;
        }

        public async Task<OrderDto> GetFindOrderCode(string orderCode)
        {
            var res = await _repository.FindOrderCodeAsync(x => x.OrderCode.Contains(orderCode));
            var model = _mapper.Map<OrderDto>(res);
            return model;
        }

        public async Task<bool> CheckOrderComplated(string deliveryCode)
        {
            var model = await _repository.CheckOrderComplated(deliveryCode);
            return model;
        }

        public async Task UpdateManagerIdInOrderAsync(string Id, string managerId)
        {
            var entity = await _repository.GetAsync(Id);

            entity.ManagerId = managerId;



            await _repository.UpdateAsync(entity);
        }





        public async Task<List<OrderDto>> GetDepartmentAngarRussianWaitingAsync()
        {
            var model = await _repository.GetDepartmentAngarRussianWaitingAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }

        public async Task<List<OrderDto>> GetDepartmentAngarRussianAssembledAsync()
        {

            var model = await _repository.GetDepartmentAngarRussianAssembledAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }



        public async Task<List<OrderDto>> GetDepartmentHalfAssambledAsync()
        {
            var model = await _repository.GetDepartmentHalfAssambledAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }

        public async Task<List<OrderDto>> GetDepartmentAllAssambledAsync()
        {

            var model = await _repository.GetDepartmentAllAssambledAsync();
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }

        public async Task UpdateOrderWeight(string Id, float Weight)
        {
            var entity = await _repository.GetAsync(Id);


            entity.WeightEnd = Weight;

            await _repository.UpdateAsync(entity);
        }

        public async Task StartMangerSession(string userId)
        {
            var user = await _userManager.FindByNameAsync(userId);
            ManagerStartStop managerStartStop = new ManagerStartStop();
            managerStartStop.Id = Guid.NewGuid().ToString("N");
            managerStartStop.AppUser = user;
            managerStartStop.StartTime = DateTime.UtcNow.AddHours(4);
            await _managerRepository.CreateAsync(managerStartStop);

        }


        public async Task StopMangerSession(string userId)
        {
            var user = await _userManager.FindByNameAsync(userId);
            var sesion = await entities.Where(e => e.AppUser == user && e.EndTime == null).FirstOrDefaultAsync();
            sesion.EndTime = DateTime.UtcNow.AddHours(4);
            await _managerRepository.UpdateAsync(sesion);

        }

        public async Task<string> CheckOrder(string orderId, string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            var order = await _repository.GetAsync(orderId);
            if (order == null) throw new Exception("Order not find");

            var managerSesion = await _managerRepository.FindManagerSession(userName);

            if (managerSesion is not null)
            {
                if (order.AppUser == null)
                {
                    order.AppUser = user;
                    await _repository.UpdateAsync(order);
                    managerSesion.Orders.Add(order);
                    await _managerRepository.UpdateAsync(managerSesion);
                    return "true";
                }
                else
                {

                    return "false";
                }
            }
            else
            {
                return "Please Start Session";
            }


            
        }

        public async Task<List<OrderDto>> Search(string query)
        {
            var model = await _repository.FindAllAsync(x=>x.OrderCode.Contains(query));
            var res = _mapper.Map<List<OrderDto>>(model);
            return res;
        }

        public async Task UpdateOrderIsProblemmingAsync(string Id)
        {
            var entity = await _repository.GetAsync(Id);


            entity.IsProblem = true;

            await _repository.UpdateAsync(entity);
        }
    }
}
