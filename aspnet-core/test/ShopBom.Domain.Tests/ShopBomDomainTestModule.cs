using ShopBom.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ShopBom
{
    [DependsOn(
        typeof(ShopBomEntityFrameworkCoreTestModule)
        )]
    public class ShopBomDomainTestModule : AbpModule
    {

    }
}