using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBom.Orders
{
    public class OrderAppService:ShopBomAppService, IOrderAppService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly OrderManager _orderManager;
        public OrderAppService(IOrderRepository orderRepository,
            OrderManager orderManager
         )
        {
            _orderRepository = orderRepository;
            _orderManager = orderManager;

        }
        public async Task<OrderDto> GetAsync(Guid id)
        {
            var customer = await _orderRepository.GetAsync(id);
            return ObjectMapper.Map<Order, OrderDto>(customer);

        }
        public async Task<OrderDto> CreateAsync(CreateUpdateOrderDto input)
        {
            var order = _orderManager.CreateAsync(input.Name, input.PhoneNumber, input.Address, input.Email,input.Note);
            await _orderRepository.InsertAsync(order);
            return ObjectMapper.Map<Order, OrderDto>(order);
        }
        public async Task<List<OrderDto>> GetListAsync()
        {
            var orders = await _orderRepository.GetListAsync();
            return ObjectMapper.Map<List<Order>, List<OrderDto>>(orders);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateOrderDto input)
        {
            var order = await _orderRepository.GetAsync(id);
            order.Name = input.Name;
            order.PhoneNumber = input.PhoneNumber;
            order.Address = input.Address;
            order.Email = input.Email;
            order.Note = input.Note;
            await _orderRepository.UpdateAsync(order);
        }
        public async Task DeleteCustomerAsync(Guid orderId)
        {
            var order = await _orderRepository.GetAsync(orderId);
            await _orderRepository.DeleteAsync(order);
        }
    }
}
