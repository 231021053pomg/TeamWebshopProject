using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Interfaces
{
    public interface IDeliveryService
    {
        Task<List<Delivery>> GetAll();

        Task<Delivery> Get(int id);

        Task<Delivery> Create(Delivery delivery);

        Task<Delivery> Update(int id, Delivery delivery);

        Task<Delivery> Delete(int id);
    }
}
