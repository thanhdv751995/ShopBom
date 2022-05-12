using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.ProductPromotions
{
    public class ProductPromotion : AuditedAggregateRoot<Guid>
    {
        public Guid IdProduct { get; set; }
        public Guid IdPromotion { get; set; }

        private ProductPromotion()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal ProductPromotion(
               Guid id,
              [NotNull] Guid idProduct,
              [NotNull] Guid idPromotion
           )
           : base(id)
        {
            IdProduct = idProduct;
            IdPromotion = idPromotion;
        }
    }
}
