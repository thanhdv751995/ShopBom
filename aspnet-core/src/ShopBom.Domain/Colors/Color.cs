using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.Colors
{
    public class Color : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        private Color()
        {

        }
        
        internal Color(
            Guid id,
            [NotNull] string name
            ) : base(id)
        {
            SetName(name);
        }
        internal Color ChangeName([NotNull] string name)
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
