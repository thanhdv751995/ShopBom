using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.ProductSizes
{
    public class ProductSize : AuditedAggregateRoot<Guid>
    {
        public Guid IdProduct { get; set; }
        public Guid IdSize { get; set; }

        private ProductSize()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal ProductSize(
               Guid id,
              [NotNull] Guid idProduct,
              [NotNull] Guid idSize
           )
           : base(id)
        {
            IdProduct = idProduct;
            IdSize = idSize;
        }
    }
}
