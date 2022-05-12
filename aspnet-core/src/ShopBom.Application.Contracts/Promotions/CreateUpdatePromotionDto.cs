using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBom.Promotions
{
    public class CreateUpdatePromotionDto
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public Guid IdProduct { get; set; }
        [Required]
        public int Percent { get; set; } // phần trăm khuyến mãi theo giá
        public DateTime Begin { get; set; }// thời gian bắt đầu

        public DateTime End { get; set; }// thời gian kết thúc
    }
}
