using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.WebUI.Models
{
    public class CheckoutConfirmModel
    {
        public Shopping.ShippingDetail Shipping { get; set; }
        public Shopping.Cart Cart { get; set; }
    }
}