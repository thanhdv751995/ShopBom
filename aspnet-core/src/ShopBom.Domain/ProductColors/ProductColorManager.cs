using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.ProductColors
{
    public class ProductColorManager : DomainService
    {
        public ProductColorManager()
        {
        }
        public ProductColor CreateAsync(
          [NotNull] Guid idProduct,
          [NotNull] Guid idColor
           )
        {
            return new ProductColor(
             GuidGenerator.Create(),
             idProduct,
             idColor
            );
        }
    }
}
