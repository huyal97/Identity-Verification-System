using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TcKimlikTest.Models;

namespace TcKimlikTest.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        IReadOnlyList<T> ListAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
