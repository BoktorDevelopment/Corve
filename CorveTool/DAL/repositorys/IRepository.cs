using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.repositorys
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
