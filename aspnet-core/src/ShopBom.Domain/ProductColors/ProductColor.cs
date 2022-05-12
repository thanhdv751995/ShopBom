using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.ProductColors
{
    public class ProductColor : AuditedAggregateRoot<Guid>
    {
        public Guid IdProduct { get; set; }
        public Guid IdColor { get; set; }

        private ProductColor()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal ProductColor(
               Guid id,
              [NotNull] Guid idProduct,
              [NotNull] Guid idColor
           )
           : base(id)
        {
            IdProduct = idProduct;
            IdColor = idColor;
        }
    }
}
