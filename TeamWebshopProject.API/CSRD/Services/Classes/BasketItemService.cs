using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class BasketItemService : IBasketItemService
    {
        private readonly IBasketItemRepository _basketItemRepository;

        public BasketItemService(IBasketItemRepository basketItemRepository)
        {
            _basketItemRepository = basketItemRepository;
        }

        public async Task<BasketItem> Create(BasketItem basketItem)
        {
            var result = await _basketItemRepository.Create(basketItem);
            return result;
        }

        public async Task<BasketItem> Delete(int id)
        {
            var result = await _basketItemRepository.Delete(id);
            return result;
        }

        public async Task<BasketItem> Get(int id)
        {
            var result = await _basketItemRepository.Get(id);
            return result;
        }

        public async Task<List<BasketItem>> GetAll()
        {
            var result = await _basketItemRepository.GetAll();
            return result;
        }

        public async Task<BasketItem> Update(int id, BasketItem basketItem)
        {
            var result = await _basketItemRepository.Update(id, basketItem);
            return result;
        }

        public async Task<List<BasketItem>> GetByBasket(int id)
        {
            var result = await _basketItemRepository.GetByBasket(id);
            return result;
        }
    }
}
