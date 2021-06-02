using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetOrderItemsList();

        Task<OrderItem> GetOrderItem(int id);

        Task<OrderItem> GetOrderItemQuantity();
    }
}
