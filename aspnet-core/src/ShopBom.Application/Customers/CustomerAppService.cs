
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBom.Customers
{
    public class CustomerAppService: ShopBomAppService, ICustomerAppService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly CustomerManager _customerManager;
        public CustomerAppService(ICustomerRepository customerRepository,
            CustomerManager customerManager
         )
        {
            _customerRepository = customerRepository;
            _customerManager = customerManager;
            
        }
        public async Task<CustomerDto> GetAsync(Guid id)
        {
            var customer = await _customerRepository.GetAsync(id);
            return ObjectMapper.Map<Customer, CustomerDto>(customer);

        }
        public async Task<CustomerDto> CreateAsync(CreateUpdateCustomerDto input)
        {
            var customer = _customerManager.CreateAsync(input.Name, input.PhoneNumber, input.Address, input.Email);

            await _customerRepository.InsertAsync(customer);
            return ObjectMapper.Map<Customer, CustomerDto>(customer);
        }
        public async Task<List<CustomerDto>> GetListAsync()
        {
            var customers = await _customerRepository.GetListAsync();
            return ObjectMapper.Map<List<Customer>, List<CustomerDto>>(customers);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateCustomerDto input)
        {
            var customer = await _customerRepository.GetAsync(id);
            customer.Name = input.Name;
            customer.PhoneNumber = input.PhoneNumber;
            customer.Address = input.Address;
            customer.Email = input.Email;
            await _customerRepository.UpdateAsync(customer);
        }
        public async Task DeleteCustomerAsync(Guid customerId)
        {
            var customer = await _customerRepository.GetAsync(customerId);
            await _customerRepository.DeleteAsync(customer);
        }
    }
}
