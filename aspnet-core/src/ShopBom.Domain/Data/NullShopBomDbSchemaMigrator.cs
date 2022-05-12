using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace ShopBom.Data
{
    /* This is used if database provider does't define
     * IShopBomDbSchemaMigrator implementation.
     */
    public class NullShopBomDbSchemaMigrator : IShopBomDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}