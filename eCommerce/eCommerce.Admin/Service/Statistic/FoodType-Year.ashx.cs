using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eCommerce.Model;
using eCommerce.Model.Controller;

namespace eCommerce.Admin.Service.Statistic
{
    /// <summary>
    /// Summary description for FoodType_Year
    /// </summary>
    public class FoodType_Year : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            //Xữ lý
            int minYear = 0, maxYear = 0;
            BillController.GetMaxMinYear(ref minYear, ref maxYear);
            string result = "[";
            int payment;
            for (int i = minYear; i < maxYear+1; i++)
            {
                if (i != maxYear)
                {
                    string a = "{ name: '" + i + "',data: [";
                    for (int j = 1; j < 12; j++)
                    {
                        payment = BillController.GetPayment(i, j);
                        a += payment + ",";
                    }
                    payment = BillController.GetPayment(i, 12);
                    a += payment + "]}";
                    result += a + ",";
                }
                else
                {
                    string a = "{ name: '" + maxYear + "',data: [";
                    for (int j = 1; j < 12; j++)
                    {
                        payment = BillController.GetPayment(maxYear, j);
                        a += payment + ",";
                    }
                    payment = BillController.GetPayment(maxYear, 12);
                    a += payment + "]}";
                    result += a;
                }
            }
            result += "]";
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