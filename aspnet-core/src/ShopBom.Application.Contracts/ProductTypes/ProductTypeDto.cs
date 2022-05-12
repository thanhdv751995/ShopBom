using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBom.ProductTypes
{
    public class ProductTypeDto
    {
        [Required]
        public string Name { get; set; }
    }
}
