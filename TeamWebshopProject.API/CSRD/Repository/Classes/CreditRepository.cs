using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class CreditRepository : ICreditRepository
    {
        private readonly TeamWebshopDbContext _context;
        public CreditRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<Credit> Create(Credit credit)
        {
            throw new NotImplementedException();
        }

        public Task<Credit> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Credit> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Credit>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Credit> Update(int id, Credit credit)
        {
            throw new NotImplementedException();
        }
    }
}
