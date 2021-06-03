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
    public class BasketRepository : IBasketRepository
    {
        private readonly TeamWebshopDbContext _context;
        public BasketRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public async Task<Basket> Create(Basket basket)
        {
            basket.CreatedAt = DateTime.Now;
            _context.Baskets.Add(basket);
            await _context.SaveChangesAsync();

            return basket;
        }

        public async Task<Basket> Delete(int id)
        {
            var basket = await _context.Baskets
                .FirstOrDefaultAsync(b => b.Id == id);

            if (basket != null || basket.DeletedAt == null)
            {
                basket.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return basket;
        }

        public async Task<Basket> Get(int id)
        {
            return await _context.Baskets
                .Where(b => b.DeletedAt == null)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<Basket>> GetAll()
        {
            return await _context.Baskets
                .Where(b => b.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Basket> Update(int id, Basket updatedBasket)
        {
            var basket = await _context.Baskets
                .FirstOrDefaultAsync(b => b.Id == id);

            if (basket != null)
            {
                basket.EditedAt = DateTime.Now;

                if (updatedBasket.Customer != null)
                    basket.Customer = updatedBasket.Customer;

                basket.Quantity = updatedBasket.Quantity;

                basket.Price = updatedBasket.Price;

                _context.Update(basket);
                await _context.SaveChangesAsync();
            }

            return basket;
        }
    }
}
