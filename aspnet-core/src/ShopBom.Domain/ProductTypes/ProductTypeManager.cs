using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.ProductTypes
{
    public class ProductTypeManager : DomainService
    {
        public ProductTypeManager()
        {
        }
        public ProductType CreateAsync(
            [NotNull] string name
            )
        {
            return new ProductType(
                GuidGenerator.Create(),
                name
                );
        }
    }
}
