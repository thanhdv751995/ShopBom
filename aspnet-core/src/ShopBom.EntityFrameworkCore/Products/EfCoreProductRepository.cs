using Microsoft.EntityFrameworkCore;
using ShopBom.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ShopBom.Products
{
    public class EfCoreProductRepository : EfCoreRepository<ShopBomDbContext, Product, Guid>, IProductRepository
    {
        public EfCoreProductRepository(
           IDbContextProvider<ShopBomDbContext> dbContextProvider)
          : base(dbContextProvider)
        {
        }
        public async Task<Product> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(color => color.Name == name);
        }
        public async Task<List<Product>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            {
                var dbSet = await GetDbSetAsync();
                return await dbSet
                    .WhereIf(
                        !filter.IsNullOrWhiteSpace(),
                        product => product.Name.Contains(filter)
                     )
                    .Skip(skipCount)
                    .Take(maxResultCount)
                    .ToListAsync();
            }
        }
    }
}
