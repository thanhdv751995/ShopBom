using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBom.Promotions
{
    public class PromotionAppService:ShopBomAppService,IPromotionAppService
    {
        private readonly IPromotionRepository _promotionRepository;
        private readonly PromotionManager _promotionManager;
        public PromotionAppService(IPromotionRepository promotionRepository,
           PromotionManager promotionManager
         )
        {
            _promotionRepository = promotionRepository;
            _promotionManager = promotionManager;

        }
        public async Task<PromotionDto> GetAsync(Guid id)
        {
            var promotion = await _promotionRepository.GetAsync(id);
            return ObjectMapper.Map<Promotion, PromotionDto>(promotion);

        }
        public async Task<PromotionDto> CreateAsync(CreateUpdatePromotionDto input)
        {
            var promotion = _promotionManager.CreateAsync(input.Name, input.IdProduct, input.Percent, input.Begin, input.End);
            await _promotionRepository.InsertAsync(promotion);
            return ObjectMapper.Map<Promotion, PromotionDto>(promotion);
        }
        public async Task<List<PromotionDto>> GetListAsync()
        {
            var promotions = await _promotionRepository.GetListAsync();
            return ObjectMapper.Map<List<Promotion>, List<PromotionDto>>(promotions);
        }

        public async Task UpdateAsync(Guid id, CreateUpdatePromotionDto input)
        {
            var promotion = await _promotionRepository.GetAsync(id);
            promotion.Name = input.Name;
            promotion.Percent = input.Percent;
            promotion.IdProduct = input.IdProduct;
            promotion.Begin = input.Begin;
            promotion.End = input.End;
            await _promotionRepository.UpdateAsync(promotion);
        }
        public async Task DeleteCustomerAsync(Guid promotionId)
        {
            var promotion = await _promotionRepository.GetAsync(promotionId);
            await _promotionRepository.DeleteAsync(promotion);
        }
    }
}
