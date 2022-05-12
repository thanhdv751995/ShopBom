using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace ShopBom
{
    [Dependency(ReplaceServices = true)]
    public class ShopBomBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "ShopBom";
    }
}
