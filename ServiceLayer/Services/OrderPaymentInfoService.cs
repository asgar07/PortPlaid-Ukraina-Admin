using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
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
    public class OrderPaymentInfoService:IOrderPaymentInfoService
    {
        private readonly IOrderPaymentInfoRepository _repository;
        private readonly IMapper _mapper;

        public OrderPaymentInfoService(IOrderPaymentInfoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        public async Task CreateAsync(OrderPaymentInfoCreateDto orderPaymentInfoDto)
        {
            orderPaymentInfoDto.Id = Guid.NewGuid().ToString("N");


            var model = _mapper.Map<OrderPaymenInfo>(orderPaymentInfoDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(string id)
        {
            var gallery = await _repository.GetAsync(id);
            await _repository.DeleteAsync(gallery);
        }

        public async Task<List<OrderPaymentInfoDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<OrderPaymentInfoDto>>(model);
            return res;
        }

        public async Task<OrderPaymentInfoEditDto> GetAsync(string id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<OrderPaymentInfoEditDto>(model);
            return res;
        }



        public async Task UpdateAsync(string Id, OrderPaymentInfoEditDto orderPaymentInfoEditDto)
        {
            var entity = await _repository.GetAsync(Id);


            _mapper.Map(orderPaymentInfoEditDto, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
