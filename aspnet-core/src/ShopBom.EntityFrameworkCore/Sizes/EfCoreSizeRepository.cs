using Microsoft.EntityFrameworkCore;
using ShopBom.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ShopBom.Sizes
{
    public class EfCoreSizeRepository : EfCoreRepository<ShopBomDbContext, Size, Guid>, ISizeRepository
    {
        public EfCoreSizeRepository(
        IDbContextProvider<ShopBomDbContext> dbContextProvider)
       : base(dbContextProvider)
        {
        }
        public async Task<Size> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(color => color.Name == name);
        }
        public async Task<List<Size>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            {
                var dbSet = await GetDbSetAsync();
                return await dbSet
                    .WhereIf(
                        !filter.IsNullOrWhiteSpace(),
                        size => size.Name.Contains(filter)
                     )
                    .Skip(skipCount)
                    .Take(maxResultCount)
                    .ToListAsync();
            }
        }
    }
}
