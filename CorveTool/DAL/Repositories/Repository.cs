using CorveTool.DAL.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class, IDb
    {
        private readonly DatabaseContext _context;

        public Repository(DatabaseContext context)
        {
            _context = context;
        }



        public void Add(T item)
        {
            _context.Set<T>().Add(item);
            _context.SaveChanges();
        }

        public async Task AddAsync(T item)
        {
             _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
        }

        public bool Any(int key)
        {
            var result = _context.Set<T>().Any(x => x.Id == key);
            return result;
        }

        public async Task<bool> AnyAsync(string key)
        {
            var result = await _context.Set<T>().AnyAsync(x => x.Id.ToString().Equals(key));
            return result;
        }

        public T Find(string key)
        {
            return  _context.Set<T>().FirstOrDefault(x => x.Id.ToString().Equals(key));
        }

        public  T Find(int key)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == key);
        }

        public async Task<T> FindAsync(string key)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id.ToString().Equals(key));
        }

        public async Task<T> FindAsync(int key)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == key);
        }

        public IQueryable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return  _context.Set<T>();
        }

        public void Remove(int key)
        {
            var record = Find(key);
            _context.Set<T>().Remove(record);
        }

        public async Task RemoveAsync(int key)
        {
            var record = await FindAsync(key);
            _context.Set<T>().Remove(record);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(T item)
        {
            _context.Set<T>().Update(item);
            SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
             _context.Set<T>().Update(item);
             await SaveChangesAsync();
        }
    }
}
