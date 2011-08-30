using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eCommerce.WebUI.Models.Account
{
    public class Login
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}