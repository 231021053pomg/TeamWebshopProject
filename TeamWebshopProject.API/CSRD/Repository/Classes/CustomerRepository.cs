using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        public Task<Customer> GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerAddressNumber()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerAddressPostCode()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerAddressSreet()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerBirthDay()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerCredit()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerFirstname()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerLastname()
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomerList()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerUsername()
        {
            throw new NotImplementedException();
        }
    }
}
