using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.Colors
{
    public class ColorManager : DomainService
    {
        public ColorManager()
        {
        }
        public Color CreateAsync(
            [NotNull] string name
            )
        {
            return new Color(
                GuidGenerator.Create(),
                name
                );
        }
    }
}
