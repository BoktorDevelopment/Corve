using CorveTool.DAL.Context;
using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public class TasksRepository : IRepository<Tasks>
    {
        private readonly DatabaseContext _context;

        public TasksRepository(DatabaseContext context)
        {
            _context = context;

        }
        public async Task Add(Tasks item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Tasks> Find(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tasks> Find(string key)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Task == key);
        }

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var entity = _context.Tasks.First(x => x.Id == id);
            _context.Tasks.Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task Update(Tasks item)
        {
            _context.Tasks.Update(item);
            await _context.SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
