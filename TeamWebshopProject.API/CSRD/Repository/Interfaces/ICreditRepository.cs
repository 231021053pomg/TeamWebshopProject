using System.Collections.Generic;
using System.Threading.Tasks;

using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Interfaces
{
    public interface ICreditRepository
    {
        Task<List<Credit>> GetCreditList();

        Task<Credit> GetCreditId(int id);

        Task<Credit> GetCreditCostomer();

        Task<Credit> GetCreditAmount();
    }
}
