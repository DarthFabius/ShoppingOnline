using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.DomainModel
{
    public class Products
    {
        [Key]
        public Guid Id;

        [Required]
        [MaxLength(250)]
        public string ShortDescription;

        [Required]
        public string Description;

        public IDictionary<string, string> Properties;
    }
    
}
