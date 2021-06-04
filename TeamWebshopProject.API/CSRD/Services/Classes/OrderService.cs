using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Create(Order order)
        {
            var result = await _orderRepository.Create(order);
            return result;
        }

        public async Task<Order> Delete(int id)
        {
            var result = await _orderRepository.Delete(id);
            return result;
        }

        public async Task<Order> Get(int id)
        {
            var result = await _orderRepository.Get(id);
            return result;
        }

        public async Task<List<Order>> GetAll()
        {
            var result = await _orderRepository.GetAll();
            return result;
        }

        public async Task<Order> Update(int id, Order order)
        {
            var result = await _orderRepository.Update(id, order);
            return result;
        }
    }
}
