using Volo.Abp.Modularity;

namespace ShopBom
{
    [DependsOn(
        typeof(ShopBomApplicationModule),
        typeof(ShopBomDomainTestModule)
        )]
    public class ShopBomApplicationTestModule : AbpModule
    {

    }
}