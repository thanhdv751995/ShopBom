using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.Orders
{
    public class OrderManager : DomainService
    {
        public OrderManager()
        {
        }
        public Order CreateAsync(
            [NotNull] string name,
            [NotNull] string phoneNumber,
            [NotNull] string address,
                      string email,
                      string note
            )
        {
            return new Order(
                GuidGenerator.Create(),
                name,
                phoneNumber,
                address,
                email,
                note
                );
        }
    }
}
