using CorveTool.DAL.Context;
using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public class CheckListRepository : IRepository<CheckList>
    {
        private readonly DatabaseContext _context;

        public CheckListRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task Add(CheckList item)
        {
            _context.CheckList.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CheckList>> GetAll()
        {
            return await _context.CheckList.ToListAsync();
        }
        public async Task<CheckList> Find(int id)
        {
            return await _context.CheckList.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Remove(int id)
        {
            var query = _context.CheckList.First(x => x.Id == id);
            _context.CheckList.Remove(query);
            await _context.SaveChangesAsync();
        }

        public async Task Update(CheckList item)
        {
            _context.CheckList.Update(item);
            await _context.SaveChangesAsync();
        }

        public Task<CheckList> Find(string key)
        {
            throw new NotImplementedException();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
