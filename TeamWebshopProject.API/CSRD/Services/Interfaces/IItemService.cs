using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Interfaces
{
    public interface IItemService
    {
        Task<List<Item>> GetAll();

        Task<Item> Get(int id);

        Task<Item> Create(Item Item);

        Task<Item> Update(int id, Item item);

        Task<Item> Delete(int id);
    }
}
