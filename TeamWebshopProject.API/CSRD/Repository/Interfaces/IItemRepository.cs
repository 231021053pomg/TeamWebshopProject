using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface IItemRepository
    {
        Task<List<Item>> GetItemsList();

        Task<Item> GetItem(int id);

        Task<Item> GetItemType();

        Task<Item> GetItemPrice();

        Task<Item> GetItemDiscount();

        Task<Item> GetItemDiscription();

        Task<Item> GetItemImage();

        Task<Item> GetItemTags();
    }
}
