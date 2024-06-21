using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repositories
{
    public class ManagerStartStopRepository : Repository<ManagerStartStop>, IManagerStartStopRepository
    {
        private readonly AppDbContext _context;
        private readonly DbSet<ManagerStartStop> entities;

        public ManagerStartStopRepository(AppDbContext context) : base(context)
        {
            _context = context;
            entities = context.Set<ManagerStartStop>();
        }

        public async Task<ManagerStartStop> FindManagerSession(string userName)
        {
            return await entities.Where(m => m.StartTime != null && m.EndTime == null).Include(m => m.Orders).FirstOrDefaultAsync();
        }
    }
}
