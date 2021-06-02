using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;


namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTagsList();

        Task<Tag> GetTag(int id);

        Task<Tag> GetName();
    }
}
