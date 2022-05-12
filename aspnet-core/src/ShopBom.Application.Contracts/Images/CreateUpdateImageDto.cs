using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBom.Images
{
    public class CreateUpdateImageDto
    {

        [Required]
        public string URl { get; set; }
        [Required]
        public Guid IdProduct { get; set; }
    }
}
