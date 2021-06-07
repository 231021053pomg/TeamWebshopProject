using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public async Task<Login> Create(Login login)
        {
            var result = await _loginRepository.Create(login);
            return result;
        }

        public async Task<Login> Delete(int id)
        {
            var result = await _loginRepository.Delete(id);
            return result;
        }

        public async Task<Login> Get(int id)
        {
            var result = await _loginRepository.Get(id);
            return result;
        }

        public async Task<List<Login>> GetAll()
        {
            var result = await _loginRepository.GetAll();
            return result;
        }

        public async Task<Login> Update(int id, Login login)
        {
            var result = await _loginRepository.Update(id, login);
            return result;
        }
    }
}
