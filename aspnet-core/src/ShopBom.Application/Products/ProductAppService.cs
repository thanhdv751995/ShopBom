using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBom.Products
{
    public class ProductAppService:ShopBomAppService, IProductAppService
    {
        private readonly IProductRepository _productRepository;
        private readonly ProductManager _productManager;
        public ProductAppService(IProductRepository productRepository,
           ProductManager productManager
         )
        {
            _productRepository = productRepository;
            _productManager = productManager;

        }
        public async Task<ProductDto> GetAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);
            return ObjectMapper.Map<Product, ProductDto>(product);

        }
        public async Task<ProductDto> CreateAsync(CreateUpdateProductDto input)
        {
            var product = _productManager.CreateAsync(input.Name, input.Price, input.IdColor, input.IdSize, input.IdProductType);
            await _productRepository.InsertAsync(product);
            return ObjectMapper.Map<Product, ProductDto>(product);
        }
        public async Task<List<ProductDto>> GetListAsync()
        {
            var products = await _productRepository.GetListAsync();
            return ObjectMapper.Map<List<Product>, List<ProductDto>>(products);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductDto input)
        {
            var product = await _productRepository.GetAsync(id);
            product.Name = input.Name;
            product.Price = input.Price;
            product.IdColor = input.IdColor;
            product.IdProductType = input.IdProductType;
            product.IdSize = input.IdSize;
            await _productRepository.UpdateAsync(product);
        }
        public async Task DeleteCustomerAsync(Guid productId)
        {
            var product = await _productRepository.GetAsync(productId);
            await _productRepository.DeleteAsync(product);
        }
    }
}
