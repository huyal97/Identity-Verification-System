using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TcKimlikTest.Core.Interfaces;
using TcKimlikTest.Models;

namespace TcKimlikTest.Data.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly UserContext _context;
        public CustomerRepository(UserContext context)
        {
            _context = context;
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Set<Customer>().FindAsync(id);
        }

        public IReadOnlyList<Customer> ListAll()
        {
            return _context.Customers.Include(r => r.TcKimlik).Include(r => r.Company).Where(r => r.TcKimlikId == r.TcKimlik.Id).ToList();
        }
        public IReadOnlyList<Customer> ListUsersWithCompany(int companyId)
        {
            return _context.Customers.Include(r => r.TcKimlik).Include(r => r.Company).Where(r => r.CompanyId == companyId).ToList();
        }



        public void Add(Customer entity)
        {
            _context.Set<Customer>().Add(entity);
            Save();
        }
        public void Delete(Customer entity)
        {
            _context.Set<Customer>().Remove(entity);
        }
        public void Update(Customer entity)
        {
            _context.Set<Customer>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
