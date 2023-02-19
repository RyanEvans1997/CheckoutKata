using CheckoutKata.Core.Models;

namespace CheckoutKata.Core.Helpers
{
    internal class ValidateSkuHelper
    {
        public static Product? ValidateSKU(Product product)
        {
            if (product is null || product.UnitPrice < 0)
            {
                return null;
            }

            return product;
        }

        public static Promotion? ValidateSKU(Promotion promotion)
        {
            if (promotion is null || promotion.Price < 0 || promotion.Quantity < 0)
            {
                return null;
            }

            return promotion;
        }
    }
}
