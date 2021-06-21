using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface ICreditRepository
    {
        Task<List<Credit>> GetAll();

        Task<Credit> Get(int id);

        Task<Credit> Create(Credit credit);

        Task<Credit> Update(int id, Credit credit);

        Task<Credit> Delete(int id);
    }
}
