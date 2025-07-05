using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryECommerceTask
{
    public class Checkout
    {
        public void checkout(Customer customer,Cart cart)
        {
            if (cart.cartIsEmpty())
            {
                throw new Exception("Cart is empty");
            }
            double Subtotal = 0;
            double ShippingFees = 30;
            List<IShippableProduct> shippableProducts=new();

            foreach(var item in cart.cartItems)
            {
                if (item.productItem.isExpired())
                {
                    throw new Exception($"{item.productItem.Name}is expired");
                }
                else
                {
                    Subtotal += item.productItem.Price * item.Quantity;
                }
                if (item.productItem.requireShipping()&&item.productItem is IShippableProduct shippable)
                {
                    for(int i = 0; i < item.Quantity; i++)
                    {
                       shippableProducts.Add(shippable);

                    }
                }
            }
            double Amount = Subtotal + ShippingFees;
            if (customer.Balance < Amount)
            {
                throw new Exception("Insufficient balance");
            }
            customer.Balance -= Amount;
            Console.WriteLine("** Shipment notice **");
            var productGroupByName = shippableProducts.GroupBy(product => product.getName());
            foreach (var product in productGroupByName)
            {
                var totalWeight = product.Sum(p => p.getWeight());

                Console.WriteLine($"{product.Count()}X {product.Key}       {totalWeight * 1000}g");

            }
            Console.WriteLine($"Total package weight {shippableProducts.Sum(product=>product.getWeight())}kg");
            Console.WriteLine("\n** Checkout receipt **");
            foreach (var item in cart.cartItems) {
                Console.WriteLine($"{item.Quantity}X {item.productItem.Name}       {item.productItem.Price * item.Quantity}");
             

            }
            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Subtotal    {Subtotal}");
            Console.WriteLine($"Shipping    {ShippingFees}");
            Console.WriteLine($"Amount      {Amount}");
        }
    }
}
