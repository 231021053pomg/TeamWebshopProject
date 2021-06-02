using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TeamWebshopDbContext _context;
        public CustomerRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<Customer> Create(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(int id, Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
