using System;

namespace eCommerce.Model.SimpleJSON
{
    public class AccountJSON
    {
        public String id { get; set; }
        public String label { get; set; }
        public String value { get; set; }

        public String Name { get; set; }
        public String Tel { get; set; }
        public String Address { get; set; }
        public String District { get; set; }
        public int DistrictId { get; set; }
        public String City { get; set; }
        public int CityId { get; set; }

        public AccountJSON()
        {
        }
    }
}
