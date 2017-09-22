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
            _context = context;
        }

        public async void Add(Users item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task<Users> FindAsync(string email)
        {

            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Users> Find(int key)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == key);
        }

        public async Task<IQueryable<Users>> GetAll()
        {
            return  _context.Users;
        }

        public async void Remove(int id)
        {
            var query = _context.Users.First(x => x.Id == id);
            _context.Users.Remove(query);
            await _context.SaveChangesAsync();
        }

        public async void Update(Users item)
        {
            _context.Users.Update(item);
            await _context.SaveChangesAsync();
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool Any(string key)
        {
            var result = _context.Users.Any(x => x.Email == key);
            return result;
        }
    }
}
