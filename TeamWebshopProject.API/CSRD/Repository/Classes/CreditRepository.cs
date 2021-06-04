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
    public class CreditRepository : ICreditRepository
    {
        private readonly TeamWebshopDbContext _context;
        public CreditRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public async Task<Credit> Create(Credit credit)
        {
            credit.CreatedAt = DateTime.Now;
            _context.Credits.Add(credit);
            await _context.SaveChangesAsync();

            return credit;
        }

        public async Task<Credit> Delete(int id)
        {
            var credit = await _context.Credits
                .FirstOrDefaultAsync(c => c.Id == id);

            if (credit != null || credit.DeletedAt == null)
            {
                credit.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return credit;
        }

        public async Task<Credit> Get(int id)
        {
            return await _context.Credits
                .Where(c => c.DeletedAt == null)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Credit>> GetAll()
        {
            return await _context.Credits
                .Where(c => c.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Credit> Update(int id, Credit updatedCredit)
        {
            var credit = await _context.Credits
                .FirstOrDefaultAsync(c => c.Id == id);

            if (credit != null)
            {
                credit.EditedAt = DateTime.Now;

                credit.CreditAmount = updatedCredit.CreditAmount;

                _context.Update(credit);
                await _context.SaveChangesAsync();
            }

            return credit;
        }
    }
}
