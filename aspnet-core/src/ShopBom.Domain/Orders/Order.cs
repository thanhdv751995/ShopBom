using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.Orders
{
    public class Order : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }

        private Order()
        {

        }

        internal Order(
            Guid id,
            [NotNull] string name,
            [NotNull] string phoneNumber,
            [NotNull] string address,
                      string email,
                      string note
            ) : base(id)
        {
            SetName(name);
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;
            Note = note;
        }
        internal Order ChangeName([NotNull] string name)
        {
            SetName(name);
            return this;
        }
        private void SetName([NotNull] string name)
        {
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name)
            );
        }

    }
}
