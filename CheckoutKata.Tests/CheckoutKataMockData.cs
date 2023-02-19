using CheckoutKata.Core.Models;

namespace CheckoutKata.Tests
{
    public static class CheckoutKataMockData
    {
        public static Product A = new Product("A", 10);
        public static Product B = new Product("B", 15);
        public static Product C = new Product("C", 40);
        public static Product D = new Product("D", 55);

        public static Product InvalidProductA = new Product("A", -10);
        public static Product InvalidProductB = new Product("B", -15);
        public static Product InvalidProductC = new Product("C", -20);
        public static Product InvalidProductD = new Product("D", -25);


        public static Promotion PromoB = new Promotion("B", 3, 40);
        public static Promotion PromoD = new Promotion("D", 2, 82.5m);

        public static TheoryData<Product> ProductData()
        {
            return new TheoryData<Product>
            {
                A, B, C, D
            };
        }

        public static TheoryData<Product[]> InvalidProductData()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { InvalidProductA, InvalidProductB, InvalidProductC, InvalidProductD }
            };
        }

        public static TheoryData<Product[]> BaseProductList()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { A, B, C, D }
            };
        }

        public static TheoryData<Product[]> PromotedListB()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { B, B, B }
            };
        }

        public static TheoryData<Product[]> PromotedListD()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { D, D }
            };
        }

        public static TheoryData<Product[]> MultiplePromotionsList()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { B, B, B, D, D }
            };
        }

        public static TheoryData<Product[]> PromotionsQuantityCheckList()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { B, B, B, B, B, D, D, D }
            };
        }

        public static TheoryData<Product[]> PromotionsTwiceList()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { B, B, B, B, B, B, D, D, D, D }
            };
        }

        public static TheoryData<Product[]> BaseCaseOneData()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { A, A, B, B, B, C, D, D }
            };
        }

        public static TheoryData<Product[]> BaseCaseTwoData()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { A, A, A, B, B, B, D, D, D, D }
            };
        }

        public static TheoryData<Product[]> BaseCaseThreeData()
        {
            return new TheoryData<Product[]>
            {
                new Product[] { A, B, B, B, B, C, C, C, D }
            };
        }
    }
}