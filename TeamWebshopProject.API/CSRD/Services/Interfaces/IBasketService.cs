using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Interfaces
{
    public interface IBasketService
    {
        Task<List<Basket>> GetAll();

        Task<Basket> Get(int id);

        Task<Basket> Create(Basket basket);

        Task<Basket> Update(int id, Basket basket);

        Task<Basket> Delete(int id);
    }
}
