namespace CheckoutKata.Core.Models
{
    public interface IProduct
    {
        string SKU { get; set; }
        decimal UnitPrice { get; set; }
    }
}