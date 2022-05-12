using System;
using System.Collections.Generic;
using System.Text;
using ShopBom.Localization;
using Volo.Abp.Application.Services;

namespace ShopBom
{
    /* Inherit your application services from this class.
     */
    public abstract class ShopBomAppService : ApplicationService
    {
        protected ShopBomAppService()
        {
            LocalizationResource = typeof(ShopBomResource);
        }
    }
}
