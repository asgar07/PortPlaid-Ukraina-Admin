using ServiceLayer.DTOs.Comment;
using ServiceLayer.DTOs.ManagerStartStop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface IManagerStartStopService
    {
        Task CreateAsync(ManagerStartStopDto managerStartStopDto);

        Task UpdateAsync(string Id, ManagerStartStopEditDto managerStartStopEditDto);
        Task DeleteAsync(string id);
        Task<List<ManagerStartStopDto>> GetAllAsync();
        Task<ManagerStartStopDto> GetAsync(string id);
    }
}
