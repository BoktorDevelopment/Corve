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
        public async void Add(CheckList item)
        {
            _context.CheckList.Add(item);
            await _context.SaveChangesAsync();
        }
        public async Task<IQueryable<CheckList>> GetAll()
        {
            return _context.CheckList;
        }

        public async void Remove(int id)
        {
            var query = _context.CheckList.First(x => x.Id == id);
            _context.CheckList.Remove(query);
            await _context.SaveChangesAsync();
        }

        public async void Update(CheckList item)
        {
            _context.CheckList.Update(item);
            await _context.SaveChangesAsync();
        }
        

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool Any(string key)
        {
            return _context.CheckList.Any(x => x.Id.ToString().Equals(key));
        }

        public Task<CheckList> FindAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<CheckList> Find(int id)
        {
            return await _context.CheckList.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
