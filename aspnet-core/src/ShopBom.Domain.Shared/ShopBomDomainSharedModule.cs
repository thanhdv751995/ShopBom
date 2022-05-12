using ShopBom.Localization;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ShopBom
{
    [DependsOn(
        typeof(AbpBackgroundJobsDomainSharedModule),
        typeof(AbpIdentityDomainSharedModule),
        typeof(AbpTenantManagementDomainSharedModule)
        )]
    public class ShopBomDomainSharedModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            ShopBomGlobalFeatureConfigurator.Configure();
            ShopBomModuleExtensionConfigurator.Configure();
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<ShopBomDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<ShopBomResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/ShopBom");

                options.DefaultResourceType = typeof(ShopBomResource);
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("ShopBom", typeof(ShopBomResource));
            });
        }
    }
}
