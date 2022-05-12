using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ShopBom.Images
{
    public interface IImageRepository : IRepository<Image, Guid>
    {
        Task<Image> FindByNameAsync(string name);

        Task<List<Image>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
