using CorveTool.DAL.Context;
using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public class SchedulesRepository : IRepository<Schedules>
    {
        private readonly DatabaseContext _context;

        public SchedulesRepository(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Schedules>> GetAll()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async void Add(Schedules item)
        {
            _context.Schedules.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Schedules> Find(int key)
        {
            return await _context.Schedules.FirstOrDefaultAsync(t => t.Id == key);
        }

        public async void Remove(int key)
        {
            var entity = _context.Schedules.First(t => t.Id == key);
            _context.Schedules.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async void Update(Schedules item)
        {
            _context.Schedules.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
