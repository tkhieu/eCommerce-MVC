using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerce.Admin.Service.Statistic
{
    /// <summary>
    /// Summary description for FoodType_Year
    /// </summary>
    public class FoodType_Year : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //Xữ ký
            //
            //
            //
            String result = "";

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}