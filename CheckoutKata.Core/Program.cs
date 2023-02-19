using CheckoutKata.Core.Models;

namespace CheckoutKata.Core
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShoppingBasket basket = new ShoppingBasket();

            Product A = new Product("A", 10);
            Product B = new Product("B", 15);
            Product C = new Product("C", 40);
            Product D = new Product("D", 55);

            Promotion PromoB = new Promotion("B", 3, 40);
            Promotion PromoD = new Promotion("D", 2, 82.5m);

            basket.AddPromotion(PromoB);
            basket.AddPromotion(PromoD);

            basket.AddProduct(B);
            basket.AddProduct(B);
            basket.AddProduct(B);

            Console.WriteLine(basket.CalculateTotalPrice());
        }
    }
}