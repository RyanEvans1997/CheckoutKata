namespace CheckoutKata.Core.Models
{
    public interface IPromotion
    {
        decimal? Price { get; set; }
        int? Quantity { get; set; }
        string SKU { get; set; }
    }
}