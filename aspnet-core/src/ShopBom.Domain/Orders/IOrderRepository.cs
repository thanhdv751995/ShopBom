﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace ShopBom.Orders
{
    public interface IOrderRepository : IRepository<Order, Guid>
    {
        Task<Order> FindByNameAsync(string name);
        Task<List<Order>> GetListAsync(
       int skipCount,
       int maxResultCount,
       string sorting,
       string filter = null
   );
    }
}
