namespace FawryECommerceTask
{
    public class Program
    {
        static void Main(string[] args)
        {
         var cheese=new ExpirableAndShippableProduct
         {
             Name = "Cheese",
             Price = 100,
             Quantity = 10,
             ExpirationDate = DateTime.Now.AddDays(5),
             productWeight = 0.2
         };
            var biscuit = new ExpirableAndShippableProduct
            {
                Name = "Biscuit",
                Price = 150,
                Quantity = 5,
                ExpirationDate = DateTime.Now.AddDays(10),
                productWeight = 0.7
            };
            var card = new NotShippableProduct
            {
                Name = "Scratch Card",
                Price = 200,
                Quantity = 10
            };
            var customer = new Customer
            {
                CustomerName = "Yomna",
                Balance = 1000
            };
            var cart = new Cart();
            cart.addToCart(cheese, 2);
            cart.addToCart(biscuit, 1);
            //cart.addToCart(card, 1);
            var checkout = new Checkout();
            checkout.checkout(customer, cart);
        }
    }
}
