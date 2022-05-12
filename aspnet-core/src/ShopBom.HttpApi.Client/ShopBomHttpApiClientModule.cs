using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace ShopBom
{
    [DependsOn(
        typeof(ShopBomApplicationContractsModule),
        typeof(AbpIdentityHttpApiClientModule),
        typeof(AbpTenantManagementHttpApiClientModule)
    )]
    public class ShopBomHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Default";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(ShopBomApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
