using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Create(Customer customer)
        {
            var result = await _customerRepository.Create(customer);
            return result;
        }

        public async Task<Customer> Delete(int id)
        {
            var result = await _customerRepository.Delete(id);
            return result;
        }

        public async Task<Customer> Get(int id)
        {
            var result = await _customerRepository.Get(id);
            return result;
        }

        public async Task<List<Customer>> GetAll()
        {
            var result = await _customerRepository.GetAll();
            return result;
        }

        public async Task<Customer> Update(int id, Customer customer)
        {
            var result = await _customerRepository.Update(id, customer);
            return result;
        }
    }
}
