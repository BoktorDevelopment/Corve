using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.repositorys
{
    public class SchedulesRepository : IRepository<Schedules>
    {
        private readonly DatabaseContext _context;

        public SchedulesRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async void Add(Schedules id)
        {
            _context.Schedules.Add(id);
            await _context.SaveChangesAsync();
        }

        public async Task<Schedules> Find(int id)
        {
            return await _context.Schedules.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Schedules>> GetAll()
        {
            return await _context.Schedules.ToListAsync();
        }

        public async void Remove(int id)
        {
            var query = _context.Schedules.First(x => x.Id == id);
            _context.Schedules.Remove(query);
           await _context.SaveChangesAsync();
        }

        public async void Update(Schedules item)
        {
            _context.Schedules.Update(item);
           await  _context.SaveChangesAsync();
        }
    }
}
