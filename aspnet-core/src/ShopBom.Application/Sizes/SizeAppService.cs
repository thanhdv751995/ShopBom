using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBom.Sizes
{
    public class SizeAppService:ShopBomAppService,ISizeAppService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly SizeManager _sizeManager;
        public SizeAppService(ISizeRepository sizeRepository,
           SizeManager sizeManager
         )
        {
            _sizeRepository = sizeRepository;
            _sizeManager = sizeManager;

        }
        public async Task<SizeDto> GetAsync(Guid id)
        {
            var size = await _sizeRepository.GetAsync(id);
            return ObjectMapper.Map<Size, SizeDto>(size);

        }
        public async Task<SizeDto> CreateAsync(CreateUpdateSizeDto input)
        {
            var size = _sizeManager.CreateAsync(input.Name);
            await _sizeRepository.InsertAsync(size);
            return ObjectMapper.Map<Size, SizeDto>(size);
        }
        public async Task<List<SizeDto>> GetListAsync()
        {
            var sizes = await _sizeRepository.GetListAsync();
            return ObjectMapper.Map<List<Size>, List<SizeDto>>(sizes);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateSizeDto input)
        {
            var size = await _sizeRepository.GetAsync(id);
            size.Name = input.Name;
            await _sizeRepository.UpdateAsync(size);
        }
        public async Task DeleteCustomerAsync(Guid sizeId)
        {
            var size = await _sizeRepository.GetAsync(sizeId);
            await _sizeRepository.DeleteAsync(size);
        }
    }
}
