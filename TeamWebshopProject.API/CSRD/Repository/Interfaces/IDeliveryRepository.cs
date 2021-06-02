using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<List<Delivery>> GetDeliveriesList();

        Task<Delivery> GetDelivery(int id);

        Task<Order> GetOrder();

        Task<Delivery> GetDeliveryStatus();
    }
}
