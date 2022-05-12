using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBom.Images
{
    public class ImageAppService:ShopBomAppService
    {
        private readonly IImageRepository _imageRepository;
        private readonly ImageManager _imageManager;
        public ImageAppService(IImageRepository imageRepository,
           ImageManager imageManager
         )
        {
            _imageRepository = imageRepository;
            _imageManager = imageManager;

        }
        public async Task<ImageDto> GetAsync(Guid id)
        {
            var image = await _imageRepository.GetAsync(id);
            return ObjectMapper.Map<Image, ImageDto>(image);

        }
        public async Task<ImageDto> CreateAsync(CreateUpdateImageDto input)
        {
            var image = _imageManager.CreateAsync(input.URl, input.IdProduct);
            await _imageRepository.InsertAsync(image);
            return ObjectMapper.Map<Image, ImageDto>(image);
        }
        public async Task<List<ImageDto>> GetListAsync()
        {
            var images = await _imageRepository.GetListAsync();
            return ObjectMapper.Map<List<Image>, List<ImageDto>>(images);
        }

        public async Task UpdateAsync(Guid id, CreateUpdateImageDto input)
        {
            var image = await _imageRepository.GetAsync(id);
            image.URl = input.URl;
            image.IdProduct = input.IdProduct;
            await _imageRepository.UpdateAsync(image);
        }
        public async Task DeleteCustomerAsync(Guid imageId)
        {
            var image = await _imageRepository.GetAsync(imageId);
            await _imageRepository.DeleteAsync(image);
        }
    }
}
