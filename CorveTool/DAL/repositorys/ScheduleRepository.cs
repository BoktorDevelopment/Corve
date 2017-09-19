using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.repositorys
{
    public class ScheduleRepository : IRepository<Schedules>
    {
        private readonly DatabaseContext context;

        public ScheduleRepository(DatabaseContext _context)
        {
            context = _context;
        }
        public async Task Add(Schedules item)
        {
            context.Schedules.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task<Schedules> Find(int id)
        {
            return await context.Schedules.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Schedules>> GetAll()
        {
            return await context.Schedules.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var query = context.Schedules.First(x => x.Id == id);
            context.Schedules.Remove(query);
            await context.SaveChangesAsync();
        }

        public async Task Update(Schedules item)
        {
            context.Schedules.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
