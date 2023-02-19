using CheckoutKata.Core.Helpers;

namespace CheckoutKata.Core.Models
{
    public class ShoppingBasket
    {
        private List<Product> _Products { get; set; } = new List<Product>();
        private List<Promotion> _Promotions { get; set; } = new List<Promotion>();

        private decimal _TotalPrice { get; set; }

        public void AddProduct(Product product)
        {
            if (ValidateSkuHelper.ValidateSKU(product) is null)
            {
                return;
            }

            _Products.Add(product);
        }

        public void AddPromotion(Promotion promotion)
        {
            if (ValidateSkuHelper.ValidateSKU(promotion) is null)
            {
                return;
            }

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
            if (_Products.Any() == false)
            {
                _TotalPrice = 0;
                return _TotalPrice;
            }

            _TotalPrice = _Products.Sum(item => item.UnitPrice);

            if (_Promotions.Any() == false)
            {
                return _TotalPrice;
            }

            HashSet<Product> removeDuplicateSKU = new HashSet<Product>(new UniqueProducts());
            foreach (var product in _Products)
            {
                removeDuplicateSKU.Add(product);
            }
            decimal PromotionDiscount = removeDuplicateSKU.Sum(CalculatePromotionPrice);

            return _TotalPrice - PromotionDiscount;
        }

        public decimal CalculatePromotionPrice(Product product)
        {
            int getBasketItemCount = _Products.Count(p => p.SKU == product.SKU);

            // Already did the null check for promotion before so we know a promotion exists
            Promotion? findRelevantPromotion = _Promotions.SingleOrDefault(promo => promo.SKU == product.SKU)!;

            if (findRelevantPromotion is null)
            {
                return 0;
            }

            var normalTotal = (getBasketItemCount - (getBasketItemCount % findRelevantPromotion.Quantity)) * product.UnitPrice;
            var totalWithPromotionsApplied = (getBasketItemCount / findRelevantPromotion.Quantity * findRelevantPromotion.Price)!;
            var priceSavedWithPromotions = normalTotal - totalWithPromotionsApplied;

            if (priceSavedWithPromotions <= 0)
            {
                return 0;
            }

            return (decimal)priceSavedWithPromotions!;
        }


    }
}
