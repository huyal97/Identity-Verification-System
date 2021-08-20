using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TcKimlikTest.Models;

namespace TcKimlikTest.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(int id);
        IReadOnlyList<Customer> ListAll();
        IReadOnlyList<Customer> ListUsersWithCompany(int companyId);
        void Add(Customer entity);
        void Update(Customer entity);
        void Delete(Customer entity);
    }
}
