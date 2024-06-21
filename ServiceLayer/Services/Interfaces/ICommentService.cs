using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ICommentService
    {
        Task CreateAsync(CommentDto commentDto);

        Task UpdateAsync(string Id, CommentEditDto commentEditDto);
        Task DeleteAsync(string id);
        Task<List<CommentDto>> GetAllAsync();
        Task<CommentEditDto> GetAsync(string id);
    }
}
