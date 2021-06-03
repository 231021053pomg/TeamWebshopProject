using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<List<Login>> GetAll();

        Task<Login> Get(int id);

        Task<Login> Create(Login login);

        Task<Login> Update(int id, Login login);

        Task<Login> Delete(int id);
    }
}
