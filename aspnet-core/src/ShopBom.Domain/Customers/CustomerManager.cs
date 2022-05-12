using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace ShopBom.Customers
{
    public class CustomerManager : DomainService
    {
        public CustomerManager()
        {
        }
        public Customer CreateAsync(
             [NotNull] string name,
            [NotNull] string phoneNumber,
            [NotNull] string address,
             string email
            )
        {
            return new Customer(
                GuidGenerator.Create(),
                name,
                phoneNumber,
                address,
                email
                );
        }
    }
}
