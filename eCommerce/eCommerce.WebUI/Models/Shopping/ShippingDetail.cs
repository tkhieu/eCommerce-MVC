using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace eCommerce.WebUI.Models.Shopping
{
    public class ShippingDetail
    {
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        
        public string SocialId { get; set; }
        

        public string Tel { get; set; }

        
        public string Address { get; set; }
        
        public string District { get; set; }
        
        public string City { get; set; }

        public int SelectAddress { get; set; }

        public IEnumerable<Address> ListAddress { get; set; }

        public bool NewAddress { get; set; }
        public int PaymentMethod { get; set; }

    }

}