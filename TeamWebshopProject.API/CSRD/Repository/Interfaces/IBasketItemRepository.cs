using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface IBasketItemRepository
    {
        Task<List<BasketItem>> GetBasketItems();

        Task<BasketItem> GetBasketItem(int id);

        Task<BasketItem> GetBasketItemQuantity();
    }
}
