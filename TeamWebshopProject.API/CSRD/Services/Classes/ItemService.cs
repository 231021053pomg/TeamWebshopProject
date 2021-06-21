using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<Item> Create(Item item)
        {
            var result = await _itemRepository.Create(item);
            return result;
        }

        public async Task<Item> Delete(int id)
        {
            var result = await _itemRepository.Delete(id);
            return result;
        }

        public async Task<Item> Get(int id)
        {
            var result = await _itemRepository.Get(id);
            return result;
        }

        public async Task<List<Item>> GetAll()
        {
            var result = await _itemRepository.GetAll();
            return result;
        }

        public async Task<Item> Update(int id, Item item)
        {
            var result = await _itemRepository.Update(id, item);
            return result;
        }
    }
}
