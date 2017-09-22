using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public interface IRepository<T> where T : class, IDb
    {
        void Add(T item);
        Task<IQueryable<T>> GetAll();
        Task<T> FindAsync(string key);
        bool Any(string key);
        Task<T> Find(int key);
        void Remove(int key);
        void Update(T item);
        void SaveChangesAsync();
    }
}
