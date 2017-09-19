using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorveTool.DAL.repositorys
{
    public interface IRepository<T> where T : class, IDb
    {
        Task Add(T item);
        Task<IEnumerable<T>> GetAll();       
        Task Remove(int key);
        Task Update(T item);
    }
}
