using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.DTOs.OrderStatus;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class OrderStatusService:IOrderStatusService
    {
        private readonly IOrderStatusRepository _repository;
        private readonly IMapper _mapper;
        public OrderStatusService(IOrderStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(OrderStatusDto orderStatusDto)
        {
            orderStatusDto.Id = Guid.NewGuid().ToString("N");


            var model = _mapper.Map<OrderStatus>(orderStatusDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(string id)
        {
            var gallery = await _repository.GetAsync(id);
            await _repository.DeleteAsync(gallery);
        }

        public async Task<List<OrderStatusDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<OrderStatusDto>>(model);
            return res;
        }

        public async Task<OrderStatusEditDto> GetAsync(string id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<OrderStatusEditDto>(model);
            return res;
        }



        public async Task UpdateAsync(string Id, OrderStatusEditDto orderStatusEditDto)
        {
            var entity = await _repository.GetAsync(Id);


            _mapper.Map(orderStatusEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateOrderStatusAsync(string Id, OrderStatusEditDto orderStatusEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderStatusEditDto.OrderCode == null)
            {
                orderStatusEditDto.OrderCode = entity.OrderCode;
            }
            if (orderStatusEditDto.Status == null)
            {
                orderStatusEditDto.Status = "Pending";
            }
            if (orderStatusEditDto.Department == null)
            {
                orderStatusEditDto.Department = "ProblemSolving";
            }




            _mapper.Map(orderStatusEditDto, entity);

            await _repository.UpdateAsync(entity);
        }


        public async Task UpdateOrderStatusAccountingAsync(string Id, OrderStatusEditDto orderStatusEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderStatusEditDto.OrderCode == null)
            {
                orderStatusEditDto.OrderCode = entity.OrderCode;
            }
            if (orderStatusEditDto.Status == null)
            {
                orderStatusEditDto.Status = "Pending";
            }
            if (orderStatusEditDto.Department == null)
            {
                orderStatusEditDto.Department = "Accounting";
            }




            _mapper.Map(orderStatusEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateOrderStatusReturnAccountingAsync(string Id, OrderStatusEditDto orderStatusEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderStatusEditDto.OrderCode == null)
            {
                orderStatusEditDto.OrderCode = entity.OrderCode;
            }
            if (orderStatusEditDto.Status == null)
            {
                orderStatusEditDto.Status = "Pending";
            }
            if (orderStatusEditDto.Department == null)
            {
                orderStatusEditDto.Department = "ReturnAccounting";
            }




            _mapper.Map(orderStatusEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateOrderStatusAngarAsync(string Id, OrderStatusEditDto orderStatusEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderStatusEditDto.OrderCode == null)
            {
                orderStatusEditDto.OrderCode = entity.OrderCode;
            }
            if (orderStatusEditDto.Status == null)
            {
                orderStatusEditDto.Status = "Delivering";
            }
            if (orderStatusEditDto.Department == null)
            {
                orderStatusEditDto.Department = "Angar";
            }




            _mapper.Map(orderStatusEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateOrderStatusNotDeliveredAsync(string Id, OrderStatusEditDto orderStatusEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderStatusEditDto.OrderCode == null)
            {
                orderStatusEditDto.OrderCode = entity.OrderCode;
            }
            if (orderStatusEditDto.Status == null)
            {
                orderStatusEditDto.Status = "Refused";
            }
            if (orderStatusEditDto.Department == null)
            {
                orderStatusEditDto.Department = "Refused";
            }




            _mapper.Map(orderStatusEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateOrderStatusHalfAssembledAsync(string Id, OrderStatusEditDto orderStatusEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderStatusEditDto.OrderCode == null)
            {
                orderStatusEditDto.OrderCode = entity.OrderCode;
            }
            if (orderStatusEditDto.Status == null)
            {
                orderStatusEditDto.Status = "Delivering";
            }
            if (orderStatusEditDto.Department == null)
            {
                orderStatusEditDto.Department = "HalfAssembled";
            }




            _mapper.Map(orderStatusEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateOrderStatusAllAssembledAsync(string Id, OrderStatusEditDto orderStatusEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderStatusEditDto.OrderCode == null)
            {
                orderStatusEditDto.OrderCode = entity.OrderCode;
            }
            if (orderStatusEditDto.Status == null)
            {
                orderStatusEditDto.Status = "Delivering";
            }
            if (orderStatusEditDto.Department == null)
            {
                orderStatusEditDto.Department = "AllAssemled";
            }




            _mapper.Map(orderStatusEditDto, entity);

            await _repository.UpdateAsync(entity);
        }


        public async Task UpdateOrderStatusAngarRussianAsync(string Id)
        {
            var entity = await _repository.GetAsync(Id);

              entity.Status = "Delivering";
           
                entity.Department = "AngarRussian";
          





            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateOrderStatusComplatedOrderAsync(string Id)
        {
            var entity = await _repository.GetAsync(Id);

            entity.Status = "Delivered";

            entity.Department = "AngarRussianComplated";


            await _repository.UpdateAsync(entity);
        }
    }
}
