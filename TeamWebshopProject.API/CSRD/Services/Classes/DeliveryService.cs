using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepository _deliveryRepository;

        public DeliveryService(IDeliveryRepository deliveryRepository)
        {
            _deliveryRepository = deliveryRepository;
        }

        public async Task<Delivery> Create(Delivery delivery)
        {
            var result = await _deliveryRepository.Create(delivery);
            return result;
        }

        public async Task<Delivery> Delete(int id)
        {
            var result = await _deliveryRepository.Delete(id);
            return result;
        }

        public async Task<Delivery> Get(int id)
        {
            var result = await _deliveryRepository.Get(id);
            return result;
        }

        public async Task<List<Delivery>> GetAll()
        {
            var result = await _deliveryRepository.GetAll();
            return result;
        }

        public async Task<Delivery> Update(int id, Delivery delivery)
        {
            var result = await _deliveryRepository.Update(id, delivery);
            return result;
        }
    }
}
