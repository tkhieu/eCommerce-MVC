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
    /// Summary description for City
    /// </summary>
    public class City : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            string searchText = context.Request.QueryString["term"];
            var collection = new Collection<CityJSON>();

            var list = CityController.GetList(searchText);
            foreach (CITY city in list)
            {
                var cityJson = new CityJSON
                {
                    id = city.ID.ToString(),
                    label = city.Name,
                    value = city.Name,
                   
                };


                collection.Add(cityJson);
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