using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBom.Colors
{
    public class CreateUpdateColorDto
    {
        [Required]
        public string Name { get; set; }
    }
}
