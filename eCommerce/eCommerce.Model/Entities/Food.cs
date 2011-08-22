using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCommerce.Model.Entities
{
    public  class Food
    {
        public int FoodId { get; set; }
        public String Name { get; set; }
        public Decimal Price { get; set; }
        public String Detail { get; set; }
        public String Image { get; set; }
        public String Category { get; set; }
    }
}
