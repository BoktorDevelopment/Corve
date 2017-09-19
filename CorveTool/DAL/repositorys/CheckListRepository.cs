using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.repositorys
{
    public class CheckListRepository : IRepository<CheckList>
    {
        private readonly DatabaseContext context;

        public CheckListRepository(DatabaseContext Context)
        {
            context = Context;
        }
        public async Task Add(CheckList item)
        {
            context.CheckList.Add(item);
            await context.SaveChangesAsync();
        }
        public async Task<IEnumerable<CheckList>> GetAll()
        {
            return await context.CheckList.ToListAsync();
        }
        public async Task<CheckList> Find(int id)
        {
            return await context.CheckList.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Remove(int id)
        {
            var query = context.CheckList.First(x => x.Id == id);
            context.CheckList.Remove(query);
            await context.SaveChangesAsync();
        }

        public async Task Update(CheckList item)
        {
            context.CheckList.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
