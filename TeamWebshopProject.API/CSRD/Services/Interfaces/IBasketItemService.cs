using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Interfaces
{
    public interface IBasketItemService
    {
        Task<List<BasketItem>> GetAll();

        Task<BasketItem> Get(int id);

        Task<BasketItem> Create(BasketItem basketItem);

        Task<BasketItem> Update(int id, BasketItem basketItem);

        Task<BasketItem> Delete(int id);

        Task<BasketItem> GetByBasket(Basket basket);
    }
}
