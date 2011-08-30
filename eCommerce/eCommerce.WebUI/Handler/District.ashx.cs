using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using eCommerce.Model;
using eCommerce.Model.Controller;
using eCommerce.Model.SimpleJSON;

namespace eCommerce.WebUI.Handler
{
    /// <summary>
    /// Summary description for District
    /// </summary>
    public class District : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string search = context.Request.QueryString["term"];
            string city = context.Request.QueryString["city"];
            var collection = new Collection<DistrictJSON>();

            var list = DistrictController.GetList(search);
            foreach (DISTRICT district in list)
            {
                if (district.CITY.Name == city)
                {
                    var districtJson = new DistrictJSON
                    {
                        id = district.ID.ToString(),
                        label = district.Name,
                        value = district.Name,

                    };


                    collection.Add(districtJson);
                }
                
               
            }

            var javaScriptSerializer = new JavaScriptSerializer();
            string jsonString = javaScriptSerializer.Serialize(collection);
            context.Response.Write(jsonString);
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