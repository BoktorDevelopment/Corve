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

        public async void Add(ScheduleTask id)
        {
            _context.ScheduleTask.Add(id);
            await _context.SaveChangesAsync();
        }

        public async Task<ScheduleTask> Find(int id)
        {
            return await _context.ScheduleTask.FirstOrDefaultAsync(x => x.Week.Equals(id));
        }

        public async Task<ScheduleTask> FindAsync(string key)
        {
            return await _context.ScheduleTask.FirstOrDefaultAsync(x => x.User == key);
        }

        public async Task<IQueryable<ScheduleTask>> GetAll()
        {
            return  _context.ScheduleTask;
        }

        public async void Remove(int id)
        {
            var query = _context.ScheduleTask.Single(x => x.Id == id);
            if (query == null) return;
            _context.ScheduleTask.Remove(query);
            await _context.SaveChangesAsync();
        }

        public async void Update(ScheduleTask item)
        {
            _context.ScheduleTask.Update(item);
            await _context.SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

      

        public bool Any(string key)
        {
            var result =_context.ScheduleTask.Any(x => x.Week == int.Parse(key));
            return result;
        }
    }
}
