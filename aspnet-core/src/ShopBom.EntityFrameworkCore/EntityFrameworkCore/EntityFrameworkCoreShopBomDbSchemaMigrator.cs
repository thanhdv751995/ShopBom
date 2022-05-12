using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopBom.Data;
using Volo.Abp.DependencyInjection;

namespace ShopBom.EntityFrameworkCore
{
    public class EntityFrameworkCoreShopBomDbSchemaMigrator
        : IShopBomDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreShopBomDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the ShopBomDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<ShopBomDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
