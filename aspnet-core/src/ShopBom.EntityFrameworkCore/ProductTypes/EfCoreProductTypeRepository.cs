using Microsoft.EntityFrameworkCore;
using ShopBom.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ShopBom.ProductTypes
{
    public class EfCoreProductTypeRepository : EfCoreRepository<ShopBomDbContext, ProductType, Guid>, IProductTypeRepository
    {
        public EfCoreProductTypeRepository(
            IDbContextProvider<ShopBomDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<ProductType> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(color => color.Name == name);
        }
        public async Task<List<ProductType>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            {
                var dbSet = await GetDbSetAsync();
                return await dbSet
                    .WhereIf(
                        !filter.IsNullOrWhiteSpace(),
                        productType => productType.Name.Contains(filter)
                     )
                    .Skip(skipCount)
                    .Take(maxResultCount)
                    .ToListAsync();
            }
        }
    }
}
