using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ShopBom.ProductTypes
{
    public interface IProductTypeRepository : IRepository<ProductType, Guid>
    {
        Task<ProductType> FindByNameAsync(string name);
        Task<List<ProductType>> GetListAsync(
       int skipCount,
       int maxResultCount,
       string sorting,
       string filter = null
   );
    }
}
