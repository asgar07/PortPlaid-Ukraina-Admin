using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Order;
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
    public class OrderItemsService:IOrderItemsService
    {
        private readonly IOrderItemsRepository _repository;
        private readonly IMapper _mapper;
        public OrderItemsService(IOrderItemsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(OrderItemsCreateDto orderItemsDto)
        {
            orderItemsDto.Id = Guid.NewGuid().ToString("N");

         
            var model = _mapper.Map<OrderItems>(orderItemsDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(string id)
        {
            var gallery = await _repository.GetAsync(id);
            await _repository.DeleteAsync(gallery);
        }

        public async Task<List<OrderItemsDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<OrderItemsDto>>(model);
            return res;
        }

        public async Task<OrderItemsEditDto> GetAsync(string id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<OrderItemsEditDto>(model);
            return res;
        }

        //public async Task<OrderItemsEditDto> GetOrderInOrderITems(string Id)
        //{
        //    var model = await _repository.GetOrderInOrderITems(Id);
        //    var res = _mapper.Map<OrderItemsEditDto>(model);
        //    return res;
        //}

        public async Task UpdateAsync(string Id, OrderItemsEditDto orderItemsEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderItemsEditDto.OrderId == null)
			{
				orderItemsEditDto.OrderId = entity.OrderId;
			}
            if (orderItemsEditDto.ProductImage == null)
			{
				orderItemsEditDto.ProductImage = entity.ProductImage;
			}
            if (orderItemsEditDto.ProductName == null)
            {
                orderItemsEditDto.ProductName = entity.ProductName;
            }
            if (orderItemsEditDto.ProductPriceLira == null)
            {
                orderItemsEditDto.ProductPriceLira = entity.ProductPriceLira;
            }
            if (orderItemsEditDto.ProductPriceRubl == null)
            {
                orderItemsEditDto.ProductPriceRubl = entity.ProductPriceRubl;
            }
            if (orderItemsEditDto.ProductLink == null)
            {
                orderItemsEditDto.ProductLink = entity.ProductLink;
            }
            if (orderItemsEditDto.ProductColor == null)
            {
                orderItemsEditDto.ProductColor = entity.ProductColor;
            }
            if (orderItemsEditDto.ProductSize == null)
            {
                orderItemsEditDto.ProductSize = entity.ProductSize;
            }
            if (orderItemsEditDto.DeliveryCode == null)
            {
                orderItemsEditDto.DeliveryCode = entity.DeliveryCode;
            }
            if (orderItemsEditDto.TransactionCode == null)
            {
                orderItemsEditDto.TransactionCode = entity.TransactionCode;
            }
            if (orderItemsEditDto.ConfirmSuccess == null)
            {
                orderItemsEditDto.ConfirmSuccess = entity.ConfirmSuccess;
            }
            if (orderItemsEditDto.CheckProduct == null)
            {
                orderItemsEditDto.CheckProduct = entity.CheckProduct;
            }
            if (orderItemsEditDto.IsAngarCheck == null)
            {
                orderItemsEditDto.IsAngarCheck = entity.IsAngarCheck;
            }

            _mapper.Map(orderItemsEditDto, entity);

                    await _repository.UpdateAsync(entity);
        }

        public async Task UpdateConfirmAsync(string Id, OrderItemsEditDto orderItemsEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderItemsEditDto.OrderId == null)
            {
                orderItemsEditDto.OrderId = entity.OrderId;
            }
            if (orderItemsEditDto.ProductImage == null)
            {
                orderItemsEditDto.ProductImage = entity.ProductImage;
            }
            if (orderItemsEditDto.ProductName == null)
            {
                orderItemsEditDto.ProductName = entity.ProductName;
            }
            if (orderItemsEditDto.ProductPriceLira == null)
            {
                orderItemsEditDto.ProductPriceLira = entity.ProductPriceLira;
            }
            if (orderItemsEditDto.ProductPriceRubl == null)
            {
                orderItemsEditDto.ProductPriceRubl = entity.ProductPriceRubl;
            }
            if (orderItemsEditDto.ProductLink == null)
            {
                orderItemsEditDto.ProductLink = entity.ProductLink;
            }
            if (orderItemsEditDto.ProductColor == null)
            {
                orderItemsEditDto.ProductColor = entity.ProductColor;
            }
            if (orderItemsEditDto.ProductSize == null)
            {
                orderItemsEditDto.ProductSize = entity.ProductSize;
            }
            if (orderItemsEditDto.DeliveryCode == null)
            {
                orderItemsEditDto.DeliveryCode = entity.DeliveryCode;
            }
            if (orderItemsEditDto.TransactionCode == null)
            {
                orderItemsEditDto.TransactionCode = entity.TransactionCode;
            }
            if (orderItemsEditDto.ConfirmSuccess == null)
            {
                orderItemsEditDto.ConfirmSuccess = true;
            }
            if (orderItemsEditDto.CheckProduct == null)
            {
                orderItemsEditDto.CheckProduct = true;
            }
            if (orderItemsEditDto.IsAngarCheck == null)
            {
                orderItemsEditDto.IsAngarCheck = entity.IsAngarCheck;
            }

            _mapper.Map(orderItemsEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateIsCheckedAngarAsync(string Id)
        {
            var entity = await _repository.GetAsync(Id);

            //if (orderItemsEditDto.Id == null)
            //{
            //    orderItemsEditDto.Id = entity.Id;
            //}
            //if (orderItemsEditDto.OrderId == null)
            //{
            //    orderItemsEditDto.OrderId = entity.OrderId;
            //}
            //if (orderItemsEditDto.ProductImage == null)
            //{
            //    orderItemsEditDto.ProductImage = entity.ProductImage;
            //}
            //if (orderItemsEditDto.ProductName == null)
            //{
            //    orderItemsEditDto.ProductName = entity.ProductName;
            //}
            //if (orderItemsEditDto.ProductPriceLira == null)
            //{
            //    orderItemsEditDto.ProductPriceLira = entity.ProductPriceLira;
            //}
            //if (orderItemsEditDto.ProductPriceRubl == null)
            //{
            //    orderItemsEditDto.ProductPriceRubl = entity.ProductPriceRubl;
            //}
            //if (orderItemsEditDto.ProductLink == null)
            //{
            //    orderItemsEditDto.ProductLink = entity.ProductLink;
            //}
            //if (orderItemsEditDto.ProductColor == null)
            //{
            //    orderItemsEditDto.ProductColor = entity.ProductColor;
            //}
            //if (orderItemsEditDto.ProductSize == null)
            //{
            //    orderItemsEditDto.ProductSize = entity.ProductSize;
            //}
            //if (orderItemsEditDto.DeliveryCode == null)
            //{
            //    orderItemsEditDto.DeliveryCode = entity.DeliveryCode;
            //}
            //if (orderItemsEditDto.TransactionCode == null)
            //{
            //    orderItemsEditDto.TransactionCode = entity.TransactionCode;
            //}
            //if (orderItemsEditDto.ConfirmSuccess == null)
            //{
            //    orderItemsEditDto.ConfirmSuccess = entity.ConfirmSuccess;
            //}
            //if (orderItemsEditDto.CheckProduct == null)
            //{
            //    orderItemsEditDto.CheckProduct = entity.CheckProduct;
            //}
            //if (orderItemsEditDto.IsAngarCheck == null)
            //{
            //    orderItemsEditDto.IsAngarCheck = true;
            //}

            //_mapper.Map(orderItemsEditDto, entity);
            entity.IsAngarCheck = true;

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateNotConfirmAsync(string Id, OrderItemsEditDto orderItemsEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderItemsEditDto.OrderId == null)
            {
                orderItemsEditDto.OrderId = entity.OrderId;
            }
            if (orderItemsEditDto.ProductImage == null)
            {
                orderItemsEditDto.ProductImage = entity.ProductImage;
            }
            if (orderItemsEditDto.ProductName == null)
            {
                orderItemsEditDto.ProductName = entity.ProductName;
            }
            if (orderItemsEditDto.ProductPriceLira == null)
            {
                orderItemsEditDto.ProductPriceLira = entity.ProductPriceLira;
            }
            if (orderItemsEditDto.ProductPriceRubl == null)
            {
                orderItemsEditDto.ProductPriceRubl = entity.ProductPriceRubl;
            }
            if (orderItemsEditDto.ProductLink == null)
            {
                orderItemsEditDto.ProductLink = entity.ProductLink;
            }
            if (orderItemsEditDto.ProductColor == null)
            {
                orderItemsEditDto.ProductColor = entity.ProductColor;
            }
            if (orderItemsEditDto.ProductSize == null)
            {
                orderItemsEditDto.ProductSize = entity.ProductSize;
            }
            if (orderItemsEditDto.DeliveryCode == null)
            {
                orderItemsEditDto.DeliveryCode = entity.DeliveryCode;
            }
            if (orderItemsEditDto.TransactionCode == null)
            {
                orderItemsEditDto.TransactionCode = entity.TransactionCode;
            }
            if (orderItemsEditDto.ConfirmSuccess == null)
            {
                orderItemsEditDto.ConfirmSuccess = false;
            }
            if (orderItemsEditDto.CheckProduct == null)
            {
                orderItemsEditDto.CheckProduct = true;
            }
            if (orderItemsEditDto.IsAngarCheck == null)
            {
                orderItemsEditDto.IsAngarCheck = entity.IsAngarCheck;
            }

            _mapper.Map(orderItemsEditDto, entity);

            await _repository.UpdateAsync(entity);
        }

        public async Task UpdateReturnIsAccountingAsync(string Id, OrderItemsEditDto orderItemsEditDto)
        {
            var entity = await _repository.GetAsync(Id);

            if (orderItemsEditDto.OrderId == null)
            {
                orderItemsEditDto.OrderId = entity.OrderId;
            }
            if (orderItemsEditDto.ProductImage == null)
            {
                orderItemsEditDto.ProductImage = entity.ProductImage;
            }
            if (orderItemsEditDto.ProductName == null)
            {
                orderItemsEditDto.ProductName = entity.ProductName;
            }
            if (orderItemsEditDto.ProductPriceLira == null)
            {
                orderItemsEditDto.ProductPriceLira = entity.ProductPriceLira;
            }
            if (orderItemsEditDto.ProductPriceRubl == null)
            {
                orderItemsEditDto.ProductPriceRubl = entity.ProductPriceRubl;
            }
            if (orderItemsEditDto.ProductLink == null)
            {
                orderItemsEditDto.ProductLink = entity.ProductLink;
            }
            if (orderItemsEditDto.ProductColor == null)
            {
                orderItemsEditDto.ProductColor = entity.ProductColor;
            }
            if (orderItemsEditDto.ProductSize == null)
            {
                orderItemsEditDto.ProductSize = entity.ProductSize;
            }
            if (orderItemsEditDto.DeliveryCode == null)
            {
                orderItemsEditDto.DeliveryCode = entity.DeliveryCode;
            }
            if (orderItemsEditDto.TransactionCode == null)
            {
                orderItemsEditDto.TransactionCode = entity.TransactionCode;
            }
            if (orderItemsEditDto.ConfirmSuccess == null)
            {
                orderItemsEditDto.ConfirmSuccess = entity.ConfirmSuccess;
            }
            if (orderItemsEditDto.CheckProduct == null)
            {
                orderItemsEditDto.CheckProduct = entity.CheckProduct;
            }
            if (orderItemsEditDto.IsAngarCheck == null)
            {
                orderItemsEditDto.IsAngarCheck = entity.IsAngarCheck;
            }

            _mapper.Map(orderItemsEditDto, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
