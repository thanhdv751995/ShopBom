using Microsoft.EntityFrameworkCore;
using ShopBom.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace ShopBom.Customers
{
    public class EfCoreCustomerRepository : EfCoreRepository<ShopBomDbContext, Customer, Guid>, ICustomerRepository
    {
        public EfCoreCustomerRepository(
            IDbContextProvider<ShopBomDbContext> dbContextProvider)
           : base(dbContextProvider)
        {
        }
        public async Task<Customer> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(color => color.Name == name);
        }
        public async Task<List<Customer>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            {
                var dbSet = await GetDbSetAsync();
                return await dbSet
                    .WhereIf(
                        !filter.IsNullOrWhiteSpace(),
                        customer => customer.Name.Contains(filter) 
                        //EF.Functions.FreeText(customer.Name , filter)
                     )
                    .Skip(skipCount)
                    .Take(maxResultCount)
                    .ToListAsync();
            }
        }
    }
}
