using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace ShoppingOnline.DomainModel
{
    public class Products
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string ShortDescription { get; set; }

        [Required]
        public string Description { get; set; }

        [NotMapped]
        public IDictionary<string, string> Properties {
            get => JsonConvert.DeserializeObject<Dictionary<string, string>>(SerializedProperties);
            set => SerializedProperties = JsonConvert.SerializeObject(value);
        }

        internal string SerializedProperties { get; set; }

        [NotMapped]
        public SellingInfo BusinessInformation { get; set; }
    }
}
