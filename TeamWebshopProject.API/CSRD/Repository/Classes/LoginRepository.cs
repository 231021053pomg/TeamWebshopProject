using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Database.Context;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class LoginRepository : ILoginRepository
    {
        private readonly TeamWebshopDbContext _context;
        public LoginRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public Task<Login> Create(Login login)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Login> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Login>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Login> Update(int id, Login login)
        {
            throw new NotImplementedException();
        }
    }
}
