using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.Promotions
{
    public class PromotionManager : DomainService
    {
        public PromotionManager()
        {
        }
        public Promotion CreateAsync(
             [NotNull] string name,
            [NotNull] Guid idProduct,
            [NotNull] int percent,
               DateTime begin,
               DateTime end
            )
        {
            return new Promotion(
                GuidGenerator.Create(),
                name,
                idProduct,
                percent,
                begin,
                end
                );
        }
    }
}
