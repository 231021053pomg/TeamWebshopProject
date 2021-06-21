using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface IDeliveryRepository
    {
        Task<List<Delivery>> GetAll();

        Task<Delivery> Get(int id);

        Task<Delivery> Create(Delivery delivery);

        Task<Delivery> Update(int id, Delivery delivery);
             
        Task<Delivery> Delete(int id);
    }
}
