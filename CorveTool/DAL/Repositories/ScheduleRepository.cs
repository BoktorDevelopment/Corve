using CorveTool.DAL.Context;
using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public class ScheduleRepository : IRepository<Schedules>
    {
        private readonly DatabaseContext _context;

        public ScheduleRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task Add(Schedules item)
        {
            _context.Schedules.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Schedules> Find(int id)
        {
            return await _context.Schedules.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Schedules> Find(string key)
        {
            return await _context.Schedules.FirstOrDefaultAsync(x => x.When.ToString().Equals(key));
        }

        public async Task<IEnumerable<Schedules>> GetAll()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var query = _context.Schedules.First(x => x.Id == id);
            _context.Schedules.Remove(query);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Schedules item)
        {
            _context.Schedules.Update(item);
            await _context.SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
