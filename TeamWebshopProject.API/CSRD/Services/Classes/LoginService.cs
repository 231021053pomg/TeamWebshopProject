using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class LoginService : ILoginService
    {
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
