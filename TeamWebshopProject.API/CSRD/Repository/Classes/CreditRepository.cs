using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class CreditRepository : ICreditRepository
    {
        public Task<Credit> GetCreditAmount()
        {
            throw new NotImplementedException();
        }

        public Task<Credit> GetCreditId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Credit>> GetCreditList()
        {
            throw new NotImplementedException();
        }
    }
}
