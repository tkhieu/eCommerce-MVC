using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAnnotationsExtensions;

namespace eCommerce.WebUI.Models.Account
{
    public class Edit
    {
        [Email]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string SocialId { get; set; }
        [Required]

        public string Tel { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        [Remote("District", "Validation")]
        public string District { get; set; }
        [Required]
        [Remote("City", "Validation")]
        public string City { get; set; }



        public string Success { get; set; }
    }
}