using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.DomainModel
{
    public class ShoppingUser
    {
        [Key]
        public int Id { get; set; }
        public virtual SecurityUserInfo SecurityInfo { get; set; }

        [Required]
        public string Email { get; set; }

        [NotMapped]
        public virtual IList<ShippingInfo> ShippingInfos { get; set; }
    }

    public class SecurityUserInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        public DateTime LastLoginDateTime { get; set; }

        public Guid SessionToken { get; set; }
    }

    public class ShippingInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string CivicNumber { get; set; }

        [Required]
        [MaxLength(5)]
        public string Cap { get; set; }
        public int City { get; set; }
        public int Prov { get; set; }
        public int Nation { get; set; }
        public string Cco { get; set; }

        public virtual ShoppingUser User { get; set; }
    }


}
