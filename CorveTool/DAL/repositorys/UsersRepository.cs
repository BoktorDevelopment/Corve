using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorveTool.DAL.Models;
using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace CorveTool.DAL.repositorys
{
    public class UsersRepository : IRepository<Users>
    {
        private readonly DatabaseContext context;
        public UsersRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public async Task Add(Users item)
        {
            context.Users.Add(item);
            await context.SaveChangesAsync();
        }

        public async Task<Users> Find(string email)
        {

            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await context.Users.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var query = context.Users.First(x => x.Id == id);
            context.Users.Remove(query);
            await context.SaveChangesAsync();
        }

        public async Task Update(Users item)
        {
            context.Users.Update(item);
            await context.SaveChangesAsync();
        }
    }
}
