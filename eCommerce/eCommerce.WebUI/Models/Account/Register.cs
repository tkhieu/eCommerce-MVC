using System.ComponentModel.DataAnnotations;

namespace eCommerce.WebUI.Models.Account
{
    public class Register
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RetypePassword { get; set; }
        public string Email { get; set; }
        
        public string Name { get; set; }
        public string SocialId { get; set; }
        public string Tel { get; set; }

        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
