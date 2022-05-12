using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.IntermediaryProductTypes
{
    public class IntermediaryProductTypeManager : DomainService
    {
        public IntermediaryProductTypeManager()
        {
        }
        public IntermediaryProductType CreateAsync(
          [NotNull] Guid idProduct,
          [NotNull] Guid idProductType
           )
        {
            return new IntermediaryProductType(
             GuidGenerator.Create(),
             idProduct,
             idProductType
            );
        }
    }
}
