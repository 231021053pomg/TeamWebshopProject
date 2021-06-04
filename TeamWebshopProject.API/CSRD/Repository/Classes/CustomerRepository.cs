using Microsoft.EntityFrameworkCore;
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

        public async Task<Customer> Create(Customer customer)
        {
            customer.CreatedAt = DateTime.Now;
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> Delete(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer != null || customer.DeletedAt == null)
            {
                customer.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return customer;
        }

        public async Task<Customer> Get(int id)
        {
            return await _context.Customers
                .Where(c => c.DeletedAt == null)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers
                .Where(c => c.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Customer> Update(int id, Customer updatedCustomer)
        {
            var customer = await _context.Customers
                 .FirstOrDefaultAsync(b => b.Id == id);

            if (customer != null)
            {
                customer.EditedAt = DateTime.Now;

                //customer.Login = updatedCustomer.Login != null ? updatedCustomer.Login : customer.Login;

                //customer.Credit = updatedCustomer.Credit != null ? updatedCustomer.Credit : customer.Credit;

                customer.UserName = updatedCustomer.UserName != null ? updatedCustomer.UserName : customer.UserName;

                customer.FirstName = updatedCustomer.FirstName != null ? updatedCustomer.FirstName : customer.FirstName;

                customer.LastName = updatedCustomer.LastName != null ? updatedCustomer.LastName : customer.LastName;

                customer.BirthDay = updatedCustomer.BirthDay != DateTime.MinValue ? updatedCustomer.BirthDay : customer.BirthDay;

                customer.AddressStreet = updatedCustomer.AddressStreet != null ? updatedCustomer.AddressStreet : customer.AddressStreet;

                customer.AddressNumber = updatedCustomer.AddressNumber;

                customer.AddressPostCode = updatedCustomer.AddressPostCode;

                _context.Update(customer);
                await _context.SaveChangesAsync();
            }

            return customer;
        }
    }
}
