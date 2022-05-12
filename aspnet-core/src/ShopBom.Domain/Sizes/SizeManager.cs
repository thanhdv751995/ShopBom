using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.Sizes
{
    public class SizeManager : DomainService
    {
        public SizeManager()
        {
        }
        public Size CreateAsync(
            [NotNull] string name
            )
        {
            return new Size(
                GuidGenerator.Create(),
                name
                );
        }
    }
}
