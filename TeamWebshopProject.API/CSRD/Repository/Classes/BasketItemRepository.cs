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
    public class BasketItemRepository : IBasketItemRepository
    {
        private readonly TeamWebshopDbContext _context;
        public BasketItemRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public async Task<BasketItem> Create(BasketItem basketItem)
        {
            basketItem.CreatedAt = DateTime.Now;
            _context.BasketItems.Add(basketItem);
            await _context.SaveChangesAsync();

            return basketItem;
        }

        public async Task<BasketItem> Delete(int id)
        {
            var basketItem = await _context.BasketItems
                .FirstOrDefaultAsync(b => b.Id == id);

            if (basketItem != null || basketItem.DeletedAt == null)
            {
                basketItem.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return basketItem;
        }

        public async Task<BasketItem> Get(int id)
        {
            return await _context.BasketItems
                .Where(b => b.DeletedAt == null)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<BasketItem>> GetAll()
        {
            return await _context.BasketItems
                .Where(b => b.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<BasketItem> Update(int id, BasketItem updatedBasketItem)
        {
            var basketItem = await _context.BasketItems
                .FirstOrDefaultAsync(b => b.Id == id);

            if (basketItem != null)
            {
                basketItem.EditedAt = DateTime.Now;

                if (updatedBasketItem.Basket != null)
                    basketItem.Basket = updatedBasketItem.Basket;

                if (updatedBasketItem.Item != null)
                    basketItem.Item = updatedBasketItem.Item;

                basketItem.Quantity = updatedBasketItem.Quantity;

                _context.Update(basketItem);
                await _context.SaveChangesAsync();
            }

            return basketItem;
        }
    }
}
