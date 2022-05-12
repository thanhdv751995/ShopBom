using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.ProductSizes
{
    public class ProductSizeManager : DomainService
    {
        public ProductSizeManager()
        {
        }
        public ProductSize CreateAsync(
          [NotNull] Guid idProduct,
          [NotNull] Guid idSize
           )
        {
            return new ProductSize(
             GuidGenerator.Create(),
             idProduct,
             idSize
            );
        }
    }
}
