using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();

        Task<Order> Get(int id);

        Task<Order> Create(Order order);

        Task<Order> Update(int id, Order order);

        Task<Order> Delete(int id);
    }
}
