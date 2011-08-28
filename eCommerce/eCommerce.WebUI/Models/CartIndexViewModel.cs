using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerce.Model.Entities;

namespace eCommerce.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public String ReturnUrl { get; set; }
    }
}