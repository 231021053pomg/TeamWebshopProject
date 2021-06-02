using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomerList();

        Task<Customer> GetCustomer(int id);

        Task<Customer> GetCustomerCredit();

        Task<Customer> GetCustomerUsername();

        Task<Customer> GetCustomerFirstname();

        Task<Customer> GetCustomerLastname();

        Task<Customer> GetCustomerBirthDay();

        Task<Customer> GetCustomerAddressSreet();

        Task<Customer> GetCustomerAddressNumber();

        Task<Customer> GetCustomerAddressPostCode();
    }
}
