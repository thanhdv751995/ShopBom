using ShopBom.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ShopBom.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class ShopBomController : AbpController
    {
        protected ShopBomController()
        {
            LocalizationResource = typeof(ShopBomResource);
        }
    }
}