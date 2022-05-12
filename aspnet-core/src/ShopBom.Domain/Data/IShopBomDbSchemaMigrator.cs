using System.Threading.Tasks;

namespace ShopBom.Data
{
    public interface IShopBomDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
