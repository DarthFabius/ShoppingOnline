using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.DomainModel
{
    public class SellingInfo
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal Amount { get; set; }

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
