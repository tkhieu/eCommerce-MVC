using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DataAnnotationsExtensions;
using eCommerce.Model;

namespace eCommerce.WebUI.Models.Account
{
    public class Register
    {
        [Required]
        [Remote("UsernameExists","Validation")]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password")]
        public string RetypePassword { get; set; }
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
        [Remote("District","Validation")]
        public string District { get; set; }
        [Required]
        [Remote("City", "Validation")]
        public string City { get; set; }


        [Required]
        public string Question { get; set; }
        [Required]
        public string Answer { get; set; }

        public List<QUESTION> ListQuestions { get; set; }
    }
}
