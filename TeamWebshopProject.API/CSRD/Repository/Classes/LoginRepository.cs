using Microsoft.EntityFrameworkCore;
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

        public async Task<Login> Create(Login login)
        {
            login.CreatedAt = DateTime.Now;
            _context.Logins.Add(login);
            await _context.SaveChangesAsync();

            return login;
        }

        public async Task<Login> Delete(int id)
        {
            var login = await _context.Logins
                .FirstOrDefaultAsync(l => l.Id == id);

            if (login != null || login.DeletedAt == null)
            {
                login.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return login;
        }

        public async Task<Login> Get(int id)
        {
            return await _context.Logins
                .Where(l => l.DeletedAt == null)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<List<Login>> GetAll()
        {
            return await _context.Logins
                .Where(l => l.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Login> Update(int id, Login Updatedlogin)
        {
            var login = await _context.Logins
                .FirstOrDefaultAsync(l => l.Id == id);

            if (login != null)
            {
                login.EditedAt = DateTime.Now;

                if (Updatedlogin.AccessType != null)
                    login.AccessType = Updatedlogin.AccessType;

                if (Updatedlogin.Email != null)
                    login.Email = Updatedlogin.Email;

                login.Password = Updatedlogin.Password;

                _context.Update(login);
                await _context.SaveChangesAsync();
            }
            return login;
        }
    }
}
