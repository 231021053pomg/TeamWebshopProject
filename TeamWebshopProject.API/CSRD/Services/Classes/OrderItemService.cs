using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamWebshopProject.API.CSRD.Repository.Interfaces;
using TeamWebshopProject.API.CSRD.Services.Interfaces;
using TeamWebshopProject.API.Models;

namespace TeamWebshopProject.API.CSRD.Services.Classes
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;

        public OrderItemService(IOrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }

        public async Task<OrderItem> Create(OrderItem orderItem)
        {
            var result = await _orderItemRepository.Create(orderItem);
            return result;
        }

        public async Task<OrderItem> Delete(int id)
        {
            var result = await _orderItemRepository.Delete(id);
            return result;
        }

        public async Task<OrderItem> Get(int id)
        {
            var result = await _orderItemRepository.Get(id);
            return result;
        }

        public async Task<List<OrderItem>> GetAll()
        {
            var result = await _orderItemRepository.GetAll();
            return result;
        }

        public async Task<OrderItem> Update(int id, OrderItem orderItem)
        {
            var result = await _orderItemRepository.Update(id, orderItem);
            return result;
        }
    }
}
