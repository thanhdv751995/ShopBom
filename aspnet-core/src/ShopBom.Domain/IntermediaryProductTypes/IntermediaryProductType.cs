using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.IntermediaryProductTypes
{
    public class IntermediaryProductType : AuditedAggregateRoot<Guid>
    {

        public Guid IdProduct { get; set; }
        public Guid IdProductType { get; set; }

        private IntermediaryProductType()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal IntermediaryProductType(
               Guid id,
              [NotNull] Guid idProduct,
              [NotNull] Guid idProductType
           )
           : base(id)
        {
            IdProduct = idProduct;
            IdProductType = idProductType;
        }
    }
}
