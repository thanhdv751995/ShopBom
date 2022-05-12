using ShopBom.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace ShopBom.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(ShopBomEntityFrameworkCoreModule),
        typeof(ShopBomApplicationContractsModule)
        )]
    public class ShopBomDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
