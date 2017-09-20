using CorveTool.DAL.Context;
using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public class ScheduleTaskRepository : IRepository<ScheduleTask>
    {
        private DatabaseContext _context;

        public ScheduleTaskRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task Add(ScheduleTask id)
        {
            _context.ScheduleTask.Add(id);
            await _context.SaveChangesAsync();
        }

        public async Task<ScheduleTask> Find(string key)
        {
            return await _context.ScheduleTask.FirstOrDefaultAsync(x => x.User.ToString().Equals(key));
        }

        public async Task<ScheduleTask> Find(int id)
        {
            return await _context.ScheduleTask.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<ScheduleTask>> GetAll()
        {
            return await _context.ScheduleTask.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var query = _context.ScheduleTask.Single(x => x.Id == id);
            if (query == null) return;
            _context.ScheduleTask.Remove(query);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ScheduleTask item)
        {
            _context.ScheduleTask.Update(item);
            await _context.SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
