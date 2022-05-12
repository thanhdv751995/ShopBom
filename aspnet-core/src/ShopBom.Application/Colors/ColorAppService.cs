using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBom.Colors
{
    public class ColorAppService :ShopBomAppService, IColorAppService
    {
        private readonly IColorRepository _colorRepository;
        private readonly ColorManager _colorManager;
        public ColorAppService(IColorRepository colorRepository,
            ColorManager colorManager
         )
        {
            _colorRepository = colorRepository;
            _colorManager = colorManager;

        }
        public async Task<ColorDto> GetAsync(Guid id)
        {
            var color = await _colorRepository.GetAsync(id);
            return ObjectMapper.Map<Color, ColorDto>(color);

        }
        public async Task<ColorDto> CreateAsync(CreateUpdateColorDto input)
        {
            var color = _colorManager.CreateAsync(input.Name);
            await _colorRepository.InsertAsync(color);
            return ObjectMapper.Map<Color, ColorDto>(color);
        }
        public async Task<List<ColorDto>> GetListAsync()
        {
            var colors = await _colorRepository.GetListAsync();
            return ObjectMapper.Map<List<Color>, List<ColorDto>>(colors);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateColorDto input)
        {
            var color = await _colorRepository.GetAsync(id);
            color.Name = input.Name;
            await _colorRepository.UpdateAsync(color);
        }
        public async Task DeleteCustomerAsync(Guid colorId)
        {
            var color = await _colorRepository.GetAsync(colorId);
            await _colorRepository.DeleteAsync(color);
        }
    }
}
