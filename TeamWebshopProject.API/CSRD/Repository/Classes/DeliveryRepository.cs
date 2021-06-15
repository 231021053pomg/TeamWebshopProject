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
    public class DeliveryRepository : IDeliveryRepository
    {
        private readonly TeamWebshopDbContext _context;
        public DeliveryRepository(TeamWebshopDbContext context)
        {
            _context = context;
        }

        public async Task<Delivery> Create(Delivery delivery)
        {
            delivery.CreatedAt = DateTime.Now;
            _context.Deliveries.Add(delivery);
            await _context.SaveChangesAsync();

            return delivery;
        }

        public async Task<Delivery> Delete(int id)
        {
            var delivery = await _context.Deliveries
                .FirstOrDefaultAsync(d => d.Id == id);

            if (delivery != null || delivery.DeletedAt == null)
            {
                delivery.DeletedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }

            return delivery;
        }

        public async Task<Delivery> Get(int id)
        {
            return await _context.Deliveries
                .Where(d => d.DeletedAt == null)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Delivery>> GetAll()
        {
            return await _context.Deliveries
                .Where(d => d.DeletedAt == null)
                .ToListAsync();
        }

        public async Task<Delivery> Update(int id, Delivery updatedDelivery)
        {
            var delivery = await _context.Deliveries
                .FirstOrDefaultAsync(d => d.Id == id);

            delivery.Status = updatedDelivery.Status != null ? updatedDelivery.Status : delivery.Status;

            _context.Update(delivery);
            await _context.SaveChangesAsync();

            return delivery;
        }
    }
}
