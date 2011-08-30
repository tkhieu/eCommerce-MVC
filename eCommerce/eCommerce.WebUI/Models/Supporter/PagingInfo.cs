using System;

namespace eCommerce.WebUI.Models.Supporter
{
    public class PagingInfo
    {
        public int TotalItem { get; set; }
        public int ItemPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages
        {
            get { return (int) Math.Ceiling((decimal) TotalItem/ItemPerPage); }
        }
    }
}