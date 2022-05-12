using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBom.ProductTypes
{
    public class ProductTypeAppService:ShopBomAppService, IProductTypeAppService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly ProductTypeManager _productTypeManager;
        public ProductTypeAppService(IProductTypeRepository productTypeRepository,
            ProductTypeManager productTypeManager
         )
        {
            _productTypeRepository = productTypeRepository;
            _productTypeManager = productTypeManager;

        }
        public async Task<ProductTypeDto> GetAsync(Guid id)
        {
            var productType = await _productTypeRepository.GetAsync(id);
            return ObjectMapper.Map<ProductType, ProductTypeDto>(productType);

        }
        public async Task<ProductTypeDto> CreateAsync(CreateUpdateProductTypeDto input)
        {
            var productType = _productTypeManager.CreateAsync(input.Name);

            await _productTypeRepository.InsertAsync(productType);
            return ObjectMapper.Map<ProductType, ProductTypeDto>(productType);
        }
        public async Task<List<ProductTypeDto>> GetListAsync()
        {
            var productTypes = await _productTypeRepository.GetListAsync();
            return ObjectMapper.Map<List<ProductType>, List<ProductTypeDto>>(productTypes);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateProductTypeDto input)
        {
            var productType = await _productTypeRepository.GetAsync(id);
            productType.Name = input.Name;
            await _productTypeRepository.UpdateAsync(productType);
        }
        public async Task DeleteCustomerAsync(Guid productTypeId)
        {
            var productType = await _productTypeRepository.GetAsync(productTypeId);
            await _productTypeRepository.DeleteAsync(productType);
        }
    }
}
