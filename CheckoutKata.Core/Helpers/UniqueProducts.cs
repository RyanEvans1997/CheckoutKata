using CheckoutKata.Core.Models;

namespace CheckoutKata.Core.Helpers
{
    public class UniqueProducts : IEqualityComparer<Product>
    {
        public bool Equals(Product p1, Product p2)
        {
            return p1.SKU.Equals(p2.SKU, StringComparison.InvariantCultureIgnoreCase);
        }

        public int GetHashCode(Product product)
        {
            return product.SKU.GetHashCode();
        }
    }
}
