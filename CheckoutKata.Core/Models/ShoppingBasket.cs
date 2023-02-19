namespace CheckoutKata.Core.Models
{
    public class ShoppingBasket
    {
        private List<Product> _Products { get; set; } = new List<Product>();
        private List<Promotion> _Promotions { get; set; } = new List<Promotion>();

        private decimal _TotalPrice { get; set; }



        public void AddProduct(Product product)
        {
            _Products.Add(product);
        }

        public void AddPromotion(Promotion promotion)
        {
            _Promotions.Add(promotion);
        }

        public void RemoveProduct(Product product)
        {
            Product productToRemove = _Products.First(p => p.SKU == product.SKU);
            _Products.Remove(productToRemove);
        }

        public void ResetBasket()
        {
            // For UX, we would ask user for 2nd permission so just mocking it here
            bool userConfirmReset = true;

            if (userConfirmReset)
            {
                _Products.Clear();
            }

        }

        public decimal CalculateTotalPrice()
        {
            throw new NotImplementedException();
        }

        public decimal CalculatePromotionPrice(Product product)
        {
            throw new NotImplementedException();

        }


    }
}
