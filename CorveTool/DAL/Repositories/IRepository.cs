using System.Collections.Generic;
using System.Threading.Tasks;

namespace CorveTool.DAL.Repositories
{
    public interface IRepository<T> where T : class, IDb
    {
        void Add(T item);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(int key);
        void Remove(int key);
        void Update(T item);
    }
}
