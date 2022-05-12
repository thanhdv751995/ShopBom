using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.Products
{
    public class Product : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public Guid IdColor { get; set; }
        public Guid IdSize { get; set; }
        public Guid IdProductType { get; set; }

        private Product()
        {

        }

        internal Product(
            Guid id,
            [NotNull] string name,
             string price,
            Guid idColor,
            Guid idSize,
            Guid idProductType
            ) : base(id)
        {
            SetName(name);
            Price = price;
            IdColor = idColor;
            IdSize = idSize;
            IdProductType = idProductType;
        }
        internal Product ChangeName([NotNull] string name)
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
