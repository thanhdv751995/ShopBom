using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBom.ProductTypes
{
    public class CreateUpdateProductTypeDto
    {
        [Required]
        public string Name { get; set; }
    }
}
