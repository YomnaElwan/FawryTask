using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FawryECommerceTask
{
    public class ExpirableAndShippableProduct : Products, IShippableProduct
    {
        public double productWeight { get; set; }

        public DateTime ExpirationDate { get; set; }
        public string getName()
        {
            return Name;
        }

        public double getWeight()
        {
            return productWeight;
        }
        public override bool isExpired()
        {
            return DateTime.Now > ExpirationDate;
        }
        public override bool requireShipping()
        {
            return true;
        }
    }
}
