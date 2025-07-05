using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryECommerceTask
{
    public class Cart
    {
        public List<CartItem> cartItems { get; set; } = new();
        public void addToCart(Products product,int productQuantity)
        {
            if (productQuantity>product.Quantity)
            {
                throw new Exception("Quantity must not be more than the available product quantity");
                
            }
            else
            {
                cartItems.Add(new CartItem { productItem=product,Quantity=productQuantity});   
            }
        }
        public bool cartIsEmpty()
        {
           return cartItems.Count()==0;
        }
    }
}
