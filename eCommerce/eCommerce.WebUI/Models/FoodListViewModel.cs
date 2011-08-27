using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerce.Model;
using eCommerce.WebUI.Models.Supporter;

namespace eCommerce.WebUI.Models
{
    public class FoodListViewModel
    {
        public IEnumerable<FOOD> Foods { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public String CurrentFoodType { get; set; }
    }
}