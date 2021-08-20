using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TcKimlikTest.BusinessLogic;
using TcKimlikTest.Core.Interfaces;
using TcKimlikTest.Interfaces;
using TcKimlikTest.Models;

namespace TcKimlikTest.Controllers
{
    public class UserController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IGenericRepository<Company> _companyRepository;
        private readonly IMersisTest _mersisTest;


        public UserController(IMersisTest MersisTest,ICustomerRepository CustomerRepository, IGenericRepository<Company> CompanyRepository, IMersisSoapBuilder SoapBuilder)
        {
            _mersisTest = MersisTest;
            _customerRepository =CustomerRepository;
            _companyRepository = CompanyRepository;
            
            
        }

        public IActionResult Register()
        {
            
            return View();
        }
        
        public IActionResult Users(int companyId)
        {
            var company =  _companyRepository.GetByIdAsync(companyId);

            IReadOnlyList<Customer> users =  _customerRepository.ListUsersWithCompany(companyId);
            
            return View( users);
        }
        [HttpPost]
        public async Task<IActionResult> Register(CustomerDTO customer)
        {
            Customer customerReturn = new Customer
            {
                TcKimlik = customer.TcKimlik,
                CompanyId = Int32.Parse(customer.CompanyName),
            };


            var company = await  _companyRepository.GetByIdAsync(customerReturn.CompanyId);
            if(company.MersisControl == true)
            {               
                bool mesisResult = _mersisTest.KisiVarMi(
                    customerReturn.TcKimlik.TCKimlikNo,
                    customerReturn.TcKimlik.Ad,
                    customerReturn.TcKimlik.Soyad,
                    customerReturn.TcKimlik.DogumYili);
                if(mesisResult == false)
                {
                    ViewBag.Error = "Tc kimlik numarası yanlış";
                    return View();
                }

            }
          
            _customerRepository.Add(customerReturn);
            
            return View();
        }

    }
}
