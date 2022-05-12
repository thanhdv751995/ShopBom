using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.Images
{
    public class Image : AuditedAggregateRoot<Guid>
    {
        public string URl { get; set; }
        public Guid IdProduct { get; set; }
        private Image()
        {
            /* This constructor is for deserialization / ORM purpose */
        }
        internal Image(
               Guid id,
             [NotNull] string url,
             [NotNull] Guid idProduct
           )
           : base(id)
        {
            URl = url;
            IdProduct = idProduct;
        }
    }
}
