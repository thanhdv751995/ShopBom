using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ShopBom.Sizes
{
    public interface ISizeRepository : IRepository<Size, Guid>
    {
        Task<Size> FindByNameAsync(string name);
        Task<List<Size>> GetListAsync(
       int skipCount,
       int maxResultCount,
       string sorting,
       string filter = null
   );
    }
}
