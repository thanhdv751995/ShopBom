using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.ProductTypes
{
    public class ProductType : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        private ProductType()
        {

        }

        internal ProductType(
            Guid id,
            [NotNull] string name
            ) : base(id)
        {
            SetName(name);
        }
        internal ProductType ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }
        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name)
            );
        }
    }
}
