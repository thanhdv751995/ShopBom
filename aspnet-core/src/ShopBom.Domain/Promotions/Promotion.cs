using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace ShopBom.Promotions
{
    public class Promotion : AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public Guid IdProduct { get; set; }
        public int Percent { get; set; } // phần trăm khuyến mãi theo giá
        public DateTime Begin { get; set; }// thời gian bắt đầu
        
        public DateTime End { get; set; }// thời gian kết thúc

        private Promotion()
        {

        }

        internal Promotion(
            Guid id,
            [NotNull] string name,
            [NotNull] Guid idProduct,
            [NotNull] int percent,
            DateTime begin,
            DateTime end
            ) : base(id)
        {
            SetName(name);
            IdProduct = idProduct;
            Percent = percent;
            Begin = begin;
            End = end;
        }
        internal Promotion ChangeName([NotNull] string name)
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
