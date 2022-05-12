using Microsoft.EntityFrameworkCore;
using ShopBom.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ShopBom.Orders
{
    public class EfCoreOrderRepository : EfCoreRepository<ShopBomDbContext, Order, Guid>, IOrderRepository
    {
        public EfCoreOrderRepository(
           IDbContextProvider<ShopBomDbContext> dbContextProvider)
          : base(dbContextProvider)
        {
        }
        public async Task<Order> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(order => order.Name == name);
        }
        public async Task<List<Order>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            {
                var dbSet = await GetDbSetAsync();
                return await dbSet
                    .WhereIf(
                        !filter.IsNullOrWhiteSpace(),
                        order => order.Name.Contains(filter)
                     )
                    .Skip(skipCount)
                    .Take(maxResultCount)
                    .ToListAsync();
            }
        }
    }
}
