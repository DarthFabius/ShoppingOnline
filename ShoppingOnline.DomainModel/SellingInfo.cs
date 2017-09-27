using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.DomainModel
{
    public class SellingInfo
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public float Amount { get; set; }

        public CurrencyType Currency { get; set; }

        [NotMapped]
        public Products Product { get; set; }
    }

    public enum CurrencyType
    {
        Euro,
        Dollars,
        Doubloons,
        Sesterzi,
        CodemotionTarallis
    }
}
