using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.ManagerStartStop;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class ManagerStartStopService:IManagerStartStopService
    {
        private readonly IManagerStartStopRepository _repository;
        private readonly IMapper _mapper;
        public ManagerStartStopService(IManagerStartStopRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(ManagerStartStopDto managerStartStopDto)
        {
            managerStartStopDto.Id = Guid.NewGuid().ToString("N");


            var model = _mapper.Map<ManagerStartStop>(managerStartStopDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(string id)
        {
            var model = await _repository.GetAsync(id);
            await _repository.DeleteAsync(model);
        }

        public async Task<List<ManagerStartStopDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<ManagerStartStopDto>>(model);
            return res;
        }

        public async Task<ManagerStartStopDto> GetAsync(string id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<ManagerStartStopDto>(model);
            return res;
        }



        public async Task UpdateAsync(string Id, ManagerStartStopEditDto managerStartStopEditDto)
        {
            var entity = await _repository.GetAsync(Id);


            _mapper.Map(managerStartStopEditDto, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
