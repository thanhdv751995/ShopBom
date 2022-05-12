using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBom.Sizes
{
    public class CreateUpdateSizeDto
    {
        [Required]
        public string Name { get; set; }
    }
}
