using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();

        Task<Customer> Get(int id);

        Task<Customer> Create(Customer customer);

        Task<Customer> Update(int id, Customer customer);

        Task<Customer> Delete(int id);
    }
}
