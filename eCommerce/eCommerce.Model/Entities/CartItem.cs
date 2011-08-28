using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCommerce.Model.Entities
{
    public class CartItem
    {
        public FOOD Food { get; set; }
        public int Quantity { get; set; }
    }
}
