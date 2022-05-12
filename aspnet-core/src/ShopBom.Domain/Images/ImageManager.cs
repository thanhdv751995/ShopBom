using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.Images
{
    public class ImageManager : DomainService
    {
        public ImageManager()
        {
        }
        public Image CreateAsync(
           [NotNull] string url,
             [NotNull] Guid idProduct
           )
        {
            return new Image(
             GuidGenerator.Create(),
            url,
            idProduct
            );
        }
    }
}
