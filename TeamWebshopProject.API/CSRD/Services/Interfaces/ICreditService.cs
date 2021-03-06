using System.Collections.Generic;
using System.Threading.Tasks;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Interfaces
{
    public interface ICreditService
    {
        Task<List<Credit>> GetAll();

        Task<Credit> Get(int id);

        Task<Credit> Create(Credit credit);

        Task<Credit> Update(int id, Credit credit);

        Task<Credit> Delete(int id);
    }
}
