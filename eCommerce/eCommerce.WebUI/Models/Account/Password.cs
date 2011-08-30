using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerce.WebUI.Models.Account
{
    public class Password
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        [StringLength(20,MinimumLength = 6,ErrorMessage = "Maximum lengh 20, Munimum lenght 6 ")]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword",ErrorMessage = "Two new passsword much match")]
        public string RetypePassword { get; set; }

        public bool Success { get; set; } 
    }
}