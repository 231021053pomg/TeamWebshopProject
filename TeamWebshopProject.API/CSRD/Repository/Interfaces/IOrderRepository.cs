using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersList();

        Task<Order> GetOrder(int id);

        Task<Order> GetOrderCustomer();

        Task<Order> GetOrderPrice();
    }
}
