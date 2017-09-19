using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.repositorys
{
    public class ScheduleTaskRepository : IRepository<ScheduleTask>
    {
        private readonly DatabaseContext _context;

        public ScheduleTaskRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task Add(ScheduleTask id)
        {
            _context.ScheduleTask.Add(id);
            await _context.SaveChangesAsync();
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
           await  _context.SaveChangesAsync();
        }
    }
}
