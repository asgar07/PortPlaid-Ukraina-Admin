using DomainLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories.Interfaces
{
    public interface IManagerStartStopRepository : IRepository<ManagerStartStop>
    {
        Task<ManagerStartStop> FindManagerSession(string userName);
    }
}
