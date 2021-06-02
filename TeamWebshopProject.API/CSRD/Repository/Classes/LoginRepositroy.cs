using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Repository.Classes
{
    public class LoginRepositroy : ILoginRepository
    {
        public Task<Login> GetLoginAccessType()
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetLoginEmail()
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetLoginId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Login> GetLoginPassword()
        {
            throw new NotImplementedException();
        }
    }
}
