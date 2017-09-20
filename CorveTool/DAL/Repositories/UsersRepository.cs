using CorveTool.DAL.Context;
using CorveTool.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public class UsersRepository : IRepository<Users>
    {
        private readonly DatabaseContext _context;

        public UsersRepository(DatabaseContext context)
        {
            this._context = context;
        }

        public async Task Add(Users item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> Find(string email)
        {

            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Users> Find(int key)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == key);
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Remove(int id)
        {
            var query = _context.Users.First(x => x.Id == id);
            _context.Users.Remove(query);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Users item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
