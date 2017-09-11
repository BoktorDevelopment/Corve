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

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async void Add(Tasks item)
        {
            _context.Tasks.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Tasks> Find(int key)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == key);
        }

        public async void Remove(int key)
        {
            var entity = _context.Tasks.First(t => t.Id == key);
            _context.Tasks.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async void Update(Tasks item)
        {
            _context.Tasks.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
