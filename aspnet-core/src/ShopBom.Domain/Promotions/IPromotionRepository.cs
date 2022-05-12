using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ShopBom.Promotions
{
    public interface IPromotionRepository : IRepository<Promotion, Guid>
    {
        Task<Promotion> FindByNameAsync(string name);
        Task<List<Promotion>> GetListAsync(
       int skipCount,
       int maxResultCount,
       string sorting,
       string filter = null
   );
    }
}
