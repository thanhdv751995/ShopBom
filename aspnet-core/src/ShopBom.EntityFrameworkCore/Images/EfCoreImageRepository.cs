using Microsoft.EntityFrameworkCore;
using ShopBom.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ShopBom.Images
{
    public class EfCoreImageRepository : EfCoreRepository<ShopBomDbContext, Image, Guid>, IImageRepository
    {
        public EfCoreImageRepository(
          IDbContextProvider<ShopBomDbContext> dbContextProvider)
         : base(dbContextProvider)
        {
        }
        public async Task<Image> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(x => x.URl == name);
        }
        public async Task<List<Image>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            {
                var dbSet = await GetDbSetAsync();
                return await dbSet
                    .WhereIf(
                        !filter.IsNullOrWhiteSpace(),
                        x => x.URl.Contains(filter)
                     )
                    .Skip(skipCount)
                    .Take(maxResultCount)
                    .ToListAsync();
            }
        }
    }
}
