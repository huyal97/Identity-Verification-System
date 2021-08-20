using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TcKimlikTest.Interfaces;
using TcKimlikTest.Models;

namespace TcKimlikTest.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly UserContext _context;
        public GenericRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public  IReadOnlyList<T> ListAll()
        {
            return _context.Set<T>().ToList();
        }

       

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
        public void Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
