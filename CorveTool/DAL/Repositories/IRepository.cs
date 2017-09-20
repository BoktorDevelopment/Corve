using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public interface IRepository<T> where T : class, IDb
    {
        Task Add(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(string key);
        Task<T> Find(int key);
        Task Remove(int key);
        Task Update(T item);
        void SaveChangesAsync();
    }
}
