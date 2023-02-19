using CheckoutKata.Core.Models;

namespace CheckoutKata.Tests
{
    public class CheckoutKataTests
    {
        private ShoppingBasket _shoppingBasket = new ShoppingBasket();

        private void LoadTestScenario(Product[] products, params Promotion[] promotions)
        {
            foreach (var product in products)
            {
                _shoppingBasket.AddProduct(product);
            }

            foreach (var promotion in promotions)
            {
                _shoppingBasket.AddPromotion(promotion);
            }
        }


        [Fact]

        public void Empty_Basket_Returns_Total_Zero()
        {

            Assert.Equal(0, _shoppingBasket.CalculateTotalPrice());
        }


        [Theory]
        [MemberData(nameof(CheckoutKataMockData.InvalidProductData), MemberType = typeof(CheckoutKataMockData))]

        public void Cannot_Add_Negative_Price_Item_To_Basket(Product[] products)
        {
            LoadTestScenario(products);

            Assert.Equal(0, _shoppingBasket.CalculateTotalPrice());
        }


        [Theory]
        [MemberData(nameof(CheckoutKataMockData.ProductData), MemberType = typeof(CheckoutKataMockData))]

        public void Individual_Products_Return_Correct_Price(Product product)
        {
            _shoppingBasket.AddProduct(product);
            Assert.Equal(product.UnitPrice, _shoppingBasket.CalculateTotalPrice());
        }


        [Theory]
        [MemberData(nameof(CheckoutKataMockData.BaseProductList), MemberType = typeof(CheckoutKataMockData))]

        public void No_Promotion_Multiple_Products_Return_Correct_Price(Product[] products)
        {
            LoadTestScenario(products);
            decimal expected = products.Sum(x => x.UnitPrice);
            Assert.Equal(expected, _shoppingBasket.CalculateTotalPrice());
        }

        [Theory]
        [MemberData(nameof(CheckoutKataMockData.PromotedListB), MemberType = typeof(CheckoutKataMockData))]

        public void Promotion_B_Successfully_Applies(Product[] products)
        {
            LoadTestScenario(products, CheckoutKataMockData.PromoB);
            decimal? expected = CheckoutKataMockData.PromoB.Price;
            Assert.Equal(expected, _shoppingBasket.CalculateTotalPrice());
        }

        [Theory]
        [MemberData(nameof(CheckoutKataMockData.PromotedListD), MemberType = typeof(CheckoutKataMockData))]

        public void Promotion_D_Successfully_Applies(Product[] products)
        {
            LoadTestScenario(products, CheckoutKataMockData.PromoD);
            decimal? expected = CheckoutKataMockData.PromoD.Price;
            Assert.Equal(expected, _shoppingBasket.CalculateTotalPrice());
        }

        [Theory]
        [MemberData(nameof(CheckoutKataMockData.MultiplePromotionsList), MemberType = typeof(CheckoutKataMockData))]

        public void Multiple_Promotions_Successfully_Applies(Product[] products)
        {
            LoadTestScenario(products, CheckoutKataMockData.PromoB, CheckoutKataMockData.PromoD);
            decimal? expected = CheckoutKataMockData.PromoB.Price + CheckoutKataMockData.PromoD.Price;
            Assert.Equal(expected, _shoppingBasket.CalculateTotalPrice());
        }

        [Theory]
        [MemberData(nameof(CheckoutKataMockData.PromotionsQuantityCheckList), MemberType = typeof(CheckoutKataMockData))]

        public void Promotions_Quantity_Only_Applies_Once(Product[] products)
        {
            LoadTestScenario(products, CheckoutKataMockData.PromoB, CheckoutKataMockData.PromoD);

            // Price of B normally: 15
            // Price of D normally: 55
            // BBB + DD + BB + D
            decimal? expected = (CheckoutKataMockData.PromoB.Price + CheckoutKataMockData.PromoD.Price) + (CheckoutKataMockData.B.UnitPrice * 2) + (CheckoutKataMockData.D.UnitPrice);
            Assert.Equal(expected, _shoppingBasket.CalculateTotalPrice());
        }

        [Theory]
        [MemberData(nameof(CheckoutKataMockData.PromotionsTwiceList), MemberType = typeof(CheckoutKataMockData))]

        public void Promotions_Quantity_Applies_Twice(Product[] products)
        {
            LoadTestScenario(products, CheckoutKataMockData.PromoB, CheckoutKataMockData.PromoD);
            decimal? expected = (CheckoutKataMockData.PromoB.Price + CheckoutKataMockData.PromoD.Price) * 2;
            Assert.Equal(expected, _shoppingBasket.CalculateTotalPrice());
        }

        [Theory]
        [MemberData(nameof(CheckoutKataMockData.BaseCaseOneData), MemberType = typeof(CheckoutKataMockData))]

        public void Normal_Customer_Base_Case_One(Product[] products)
        {
            LoadTestScenario(products, CheckoutKataMockData.PromoB, CheckoutKataMockData.PromoD);
            decimal? expected = (CheckoutKataMockData.PromoB.Price + CheckoutKataMockData.PromoD.Price) * 2;
            Assert.Equal(182.5m, _shoppingBasket.CalculateTotalPrice());
        }

        [Theory]
        [MemberData(nameof(CheckoutKataMockData.BaseCaseTwoData), MemberType = typeof(CheckoutKataMockData))]
        public void Normal_Customer_Base_Case_Two(Product[] products)
        {
            LoadTestScenario(products, CheckoutKataMockData.PromoB, CheckoutKataMockData.PromoD);
            decimal? expected = (CheckoutKataMockData.PromoB.Price + CheckoutKataMockData.PromoD.Price) * 2;
            Assert.Equal(235, _shoppingBasket.CalculateTotalPrice());
        }

        [Theory]
        [MemberData(nameof(CheckoutKataMockData.BaseCaseThreeData), MemberType = typeof(CheckoutKataMockData))]
        public void Normal_Customer_Base_Case_Three(Product[] products)
        {
            LoadTestScenario(products, CheckoutKataMockData.PromoB, CheckoutKataMockData.PromoD);
            decimal? expected = (CheckoutKataMockData.PromoB.Price + CheckoutKataMockData.PromoD.Price) * 2;
            Assert.Equal(240, _shoppingBasket.CalculateTotalPrice());
        }
    }
}