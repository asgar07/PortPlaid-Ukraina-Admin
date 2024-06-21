using AutoMapper;
using DomainLayer.Entities;
using RepositoryLayer.Repositories.Interfaces;
using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.OrderItems;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CommentService:ICommentService
    {
        private readonly ICommentRepository _repository;
        private readonly IMapper _mapper;
        public CommentService(ICommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CommentDto commentDto)
        {
            commentDto.Id = Guid.NewGuid().ToString("N");


            var model = _mapper.Map<Comments>(commentDto);
            await _repository.CreateAsync(model);
        }

        public async Task DeleteAsync(string id)
        {
            var gallery = await _repository.GetAsync(id);
            await _repository.DeleteAsync(gallery);
        }

        public async Task<List<CommentDto>> GetAllAsync()
        {
            var model = await _repository.GetAllAsync();
            var res = _mapper.Map<List<CommentDto>>(model);
            return res;
        }

        public async Task<CommentEditDto> GetAsync(string id)
        {
            var model = await _repository.GetAsync(id);
            var res = _mapper.Map<CommentEditDto>(model);
            return res;
        }



        public async Task UpdateAsync(string Id, CommentEditDto commentEditDto)
        {
            var entity = await _repository.GetAsync(Id);


            _mapper.Map(commentEditDto, entity);

            await _repository.UpdateAsync(entity);
        }
    }
}
