using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;


namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetAll();

        Task<Tag> Get(int id);

        Task<Tag> Create(Tag tag);

        Task<Tag> Update(int id, Tag tag);

        Task<Tag> Delete(int id);
    }
}
