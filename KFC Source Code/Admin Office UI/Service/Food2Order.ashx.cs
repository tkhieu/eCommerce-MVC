using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Model;
using Model.SimpleJSON;

namespace ContosoWebApp.Service
{
    /// <summary>
    /// Summary description for Food2Order
    /// </summary>
    public class Food2Order : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string searchText = context.Request.QueryString["term"];
            var collection = new Collection<FoodJSON>();

            var list = FoodController.GetList(searchText);
            foreach (FOOD account in list)
            {
                var foodJson = new FoodJSON
                                   {
                                       id = account.ID.ToString(),
                                       label = account.Name,
                                       value = account.Name,
                                       Name = account.Name,
                                       Price = account.Price.ToString()
                                   };



                collection.Add(foodJson);
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