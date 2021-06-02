using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<Login> GetLoginId(int id);

        Task<Login> GetLoginAccessType();

        Task<Login> GetLoginEmail();

        Task<Login> GetLoginPassword();
    }
}
