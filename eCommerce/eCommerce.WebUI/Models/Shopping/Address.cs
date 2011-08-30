using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.WebUI.Models.Shopping
{
    public class Address
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }
        public string Add { get; set; }
        public int District { get; set; }
        public int City{ get; set; }
        public string FullAdd { get; set; }
    }
}