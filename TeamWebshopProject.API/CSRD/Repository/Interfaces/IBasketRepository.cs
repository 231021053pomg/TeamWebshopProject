using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface IBasketRepository
    {
        Task<List<Basket>> GetBasket();

        Task<Basket> GetBasketCustomer(int id);

        Task<Basket> GetBasketQuantity();

        Task<Basket> GetBasketPrice();

        Task<Basket> GetBasketCreatedAt();
    }
}
