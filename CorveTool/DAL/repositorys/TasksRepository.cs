using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.repositorys
{
    public class TasksRepository : IRepository<Tasks>
    {
        private readonly DatabaseContext _context;

        public TasksRepository(DatabaseContext context)
        {
            _context = context;
           
        }
        public async void Add(Tasks item)
        {
            _context.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Tasks> Find(int id)
        {
            return await _context.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Tasks>> GetAll()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async void Remove(int id)
        {
            var entity = _context.Tasks.First(x => x.Id == id);
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
