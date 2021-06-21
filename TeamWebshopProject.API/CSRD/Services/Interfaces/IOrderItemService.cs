using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Interfaces
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetAll();

        Task<OrderItem> Get(int id);

        Task<OrderItem> Create(OrderItem orderItem);

        Task<OrderItem> Update(int id, OrderItem orderItem);

        Task<OrderItem> Delete(int id);
    }
}
