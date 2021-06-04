using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepository _basketRepository;

        public BasketService(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }
        public async Task<Basket> Create(Basket basket)
        {
            var result = await _basketRepository.Create(basket);
            return result;
        }

        public async Task<Basket> Delete(int id)
        {
            var result = await _basketRepository.Delete(id);
            return result;
        }

        public async Task<Basket> Get(int id)
        {
            var result = await _basketRepository.Get(id);
            return result;
        }

        public async Task<List<Basket>> GetAll()
        {
            var result = await _basketRepository.GetAll();
            return result;
        }

        public async Task<Basket> Update(int id, Basket basket)
        {
            var result = await _basketRepository.Update(id, basket);
            return result;
        }
    }
}
