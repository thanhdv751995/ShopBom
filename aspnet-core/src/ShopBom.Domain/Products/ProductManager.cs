using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.Products
{
    public class ProductManager : DomainService
    {
        public ProductManager()
        {
        }
        public Product CreateAsync(
            [NotNull] string name,
             string price,
            Guid? idColor,
            Guid? idSize,
            Guid? idProductType
            )
        {
            return new Product(
                GuidGenerator.Create(),
                name,
                price,
                idColor,
                idSize,
                idProductType
                );
        }
    }
}
