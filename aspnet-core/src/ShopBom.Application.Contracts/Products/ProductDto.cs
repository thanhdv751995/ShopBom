using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBom.Products
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }
        public string Price { get; set; }
        public Guid IdColor { get; set; }
        public Guid IdSize { get; set; }
        public Guid IdProductType { get; set; }
    }
}
