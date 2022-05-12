using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.ProductPromotions
{
    public class ProductPromotionManager : DomainService
    {

        public ProductPromotionManager()
        {
        }
        public ProductPromotion CreateAsync(
          [NotNull] Guid idProduct,
          [NotNull] Guid idPromotion
           )
        {
            return new ProductPromotion(
             GuidGenerator.Create(),
             idProduct,
             idPromotion
            );
        }
    }
}
