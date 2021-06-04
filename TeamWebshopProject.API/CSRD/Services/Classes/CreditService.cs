using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class CreditService : ICreditService
    {
        private readonly ICreditRepository _creditRepository;

        public CreditService(ICreditRepository creditRepository)
        {
            _creditRepository = creditRepository;
        }

        public async Task<Credit> Create(Credit credit)
        {
            var result = await _creditRepository.Create(credit);
            return result;
        }

        public async Task<Credit> Delete(int id)
        {
            var result = await _creditRepository.Delete(id);
            return result;
        }

        public async Task<Credit> Get(int id)
        {
            var result = await _creditRepository.Get(id);
            return result;
        }

        public async Task<List<Credit>> GetAll()
        {
            var result = await _creditRepository.GetAll();
            return result;
        }

        public async Task<Credit> Update(int id, Credit credit)
        {
            var result = await _creditRepository.Update(id, credit);
            return result;
        }
    }
}
