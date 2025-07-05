using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryECommerceTask
{
    public class Products
    {
       
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public virtual bool isExpired()
        {
            return false;
        }
        public virtual bool requireShipping()
        {
            return false;
        }
      

    }
}
